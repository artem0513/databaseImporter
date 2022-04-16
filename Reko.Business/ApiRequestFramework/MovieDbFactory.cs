using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Reko.Business.ApiRequestFramework.ApiRequests;
using Reko.Contracts.ApiRequestFramework;

[assembly: InternalsVisibleTo("DM.MovieApi.IntegrationTests")]

namespace Reko.Business.ApiRequestFramework
{
    public static class MovieDbFactory
    {
        public static bool IsFactoryComposed => Settings != null;

        public static IMovieDbSettings Settings { get; private set; }

        static MovieDbFactory()
        {
            RegisterSettings("c16c2149a0a3a86cc5d5767a100bb386");
        }

        public static void RegisterSettings(IMovieDbSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            ResetFactory();

            Settings = settings;
        }

        public static void RegisterSettings(string apiKey, string apiUrl = "http://api.themoviedb.org/3/")
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException(nameof(apiKey));
            }

            if (string.IsNullOrWhiteSpace(apiUrl))
            {
                throw new ArgumentException(nameof(apiUrl));
            }

            var settings = new MovieDbSettings(apiKey, apiUrl);

            RegisterSettings(settings);
        }

        public static Lazy<T> Create<T>() where T : IApiRequest
        {
            var type = typeof(T);
            if (type.IsInterface || type.IsAbstract)
                throw new ArgumentException("Specify api request type. It shouldn't be an interface or abstract class.");

            ContainerGuard();

            var requestResolver = new ApiRequestResolver();

            return new Lazy<T>(requestResolver.Get<T>);
        }


        public static void ResetFactory()
        {
            Settings = null;
        }

        private static void ContainerGuard()
        {
            if (!IsFactoryComposed)
                throw new InvalidOperationException($"{nameof(RegisterSettings)} must be called before the Factory can Create anything.");
        }

        private class MovieDbSettings : IMovieDbSettings
        {
            public string ApiKey { get; }
            public string ApiUrl { get; }

            public MovieDbSettings(string apiKey, string apiUrl)
            {
                ApiKey = apiKey;
                ApiUrl = apiUrl;
            }
        }

        private class ApiRequestResolver
        {
            private static readonly IReadOnlyDictionary<Type, Func<object>> SupportedDependencyTypeMap;
            private static readonly ConcurrentDictionary<Type, ConstructorInfo> TypeCtorMap;

            static ApiRequestResolver()
            {
                SupportedDependencyTypeMap = new Dictionary<Type, Func<object>>
                {
                    {typeof(IMovieDbSettings), () => Settings},
                    {typeof(IApiGenreRequest), () => new ApiGenreRequest(Settings)}
                };

                TypeCtorMap = new ConcurrentDictionary<Type, ConstructorInfo>();
            }

            public T Get<T>() where T : IApiRequest
            {
                var ctor = TypeCtorMap.GetOrAdd(typeof(T), GetConstructor);

                var param = ctor.GetParameters();

                if (param.Length == 0) return (T) ctor.Invoke(null);

                var paramObjects = new List<object>(param.Length);
                foreach (var p in param)
                {
                    if (SupportedDependencyTypeMap.ContainsKey(p.ParameterType) == false)
                        throw new InvalidOperationException(
                            $"{p.ParameterType.FullName} is not a supported dependency type for {typeof(T).FullName}.");

                    var typeResolver = SupportedDependencyTypeMap[p.ParameterType];

                    paramObjects.Add(typeResolver());
                }

                return (T) ctor.Invoke(paramObjects.ToArray());
            }

            private static ConstructorInfo GetConstructor(Type t)
            {
                var ctors = GetAvailableConstructors(t.GetTypeInfo());

                if (ctors.Length == 0) throw new InvalidOperationException($"No public constructors found for {t.FullName}.");

                if (ctors.Length == 1) return ctors[0];

                var markedCtors = ctors
                    .Where(x => x.IsDefined(typeof(ImportingConstructorAttribute)))
                    .ToArray();

                if (markedCtors.Length != 1)
                    throw new InvalidOperationException(
                        "Multiple public constructors found.  Please mark the one to use with the FactoryConstructorAttribute.");

                return markedCtors[0];
            }

            private static ConstructorInfo[] GetAvailableConstructors(TypeInfo typeInfo)
            {
                var implementingTypes = typeInfo.Assembly.DefinedTypes
                    .Where(x => x.IsAbstract == false)
                    .Where(x => x.IsInterface == false)
                    .Where(typeInfo.IsAssignableFrom)
                    .ToArray();

                if (implementingTypes.Length != 1)
                    throw new NotSupportedException("Multiple implementing requests per request interface is not currently supported.");

                return implementingTypes[0].DeclaredConstructors.ToArray();
            }
        }
    }
}