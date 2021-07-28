using System.IO;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.Core.Models;
using Microsoft.Extensions.Configuration;
using File = AutomatSellingDrink.DataAccess.Entities.File;

namespace AutomatSellingDrink.DataAccess.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly IMapper _mapper;
        private string _path;

        public SettingsRepository(IConfiguration Configuration, IMapper mapper)
        {
            _mapper = mapper;
            _path = Configuration.GetSection("PathSettings").Value;
            DirectoryInfo dirInfo = new DirectoryInfo(_path);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            
            FileInfo fileInfo = new FileInfo(Path.Combine(_path, "settings.txt"));
            if (!fileInfo.Exists)
            {
                //fileInfo.Create();
                SaveSettingsAsync(new Settings()
                {
                    IsAllowUpload1Coin = true,
                    IsAllowUpload2Coin = true,
                    IsAllowUpload5Coin = true,
                    IsAllowUpload10Coin = true
                });
            }
            
        }
        
        public async Task SaveSettingsAsync(Core.Models.Settings settings)
        {
            string json = JsonSerializer.Serialize<Entities.Settings>(_mapper.Map<Core.Models.Settings,Entities.Settings>(settings));
            try
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(_path, "settings.txt")))
                {
                    await outputFile.WriteLineAsync(json);
                }
            }
            catch (Exception e)
            {
                throw new FieldAccessException("Ошибка записи в файл");
            }

        }
        
        public async Task<Core.Models.Settings> LoadSettingsAsync()
        {
            string json;
            Entities.Settings settings = null;
            try
            {
                using (var sr = new StreamReader($"{_path}\\settings.txt"))
                {
                    json = await sr.ReadToEndAsync();
                }
            
                settings = JsonSerializer.Deserialize<Entities.Settings>(json);
            }
            catch (Exception e)
            {
                throw new FileNotFoundException("Файл с настройками не найден, или он пустой.");
            }

            return _mapper.Map<Entities.Settings, Core.Models.Settings>(settings);
        }
        
    }
}