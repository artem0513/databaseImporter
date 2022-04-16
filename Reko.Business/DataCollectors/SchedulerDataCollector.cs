using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Reko.Contracts.Managers;
using Reko.Models.Models;

namespace Reko.Business.DataCollectors
{
    public sealed class SchedulerDataCollector : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private Timer _timer;
        private DailyDataCollectorSettings _settings;

        private static readonly string _settingsFile =
            $"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\\DataCollectors\\updater.json";

        public SchedulerDataCollector(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var json = File.ReadAllText(_settingsFile);
            _settings = JsonConvert.DeserializeObject<DailyDataCollectorSettings>(json);

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(_settings.Interval));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            if (DateTime.TryParse(_settings.LastUpdatedDate, out var lastTime) &&
                (DateTime.UtcNow - lastTime).TotalSeconds < _settings.Interval)
            {
                return;
            }

            var yesterday = DateTime.Now.AddDays(-1);

            _serviceScopeFactory.CreateScope().ServiceProvider.GetService<IDataCollectorManager>()
                .Collect(yesterday, yesterday, CancellationToken.None);
            _settings.LastUpdatedDate = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            var json = JsonConvert.SerializeObject(_settings);
            File.WriteAllText(_settingsFile, json);
        }
    }
}