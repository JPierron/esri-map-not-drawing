using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Vigie.Risques.Tpm.Core.Services
{
    public class MapVectorCacheService
    {
        private const string ASSEMBLY_RESOURCES_PATH = "Vigie.Risques.Tpm.Core.Resources.";
        private const string MAP_PACKAGE_FOLDER = "mapCache";
        private const string MAP_PACKAGE_NAME = "m_tpm_street.vtpk";

        private FileStream _mapPackageFileStream;

        /// <summary>
        /// Event raised on init
        /// </summary>
        public event EventHandler OnInitEnd;

        public async Task InitMapCache()
        {
            var appDataFolderPath = FileSystem.AppDataDirectory;
            var mapPackageDirectoryPath = Path.Combine(appDataFolderPath, MAP_PACKAGE_FOLDER);
            if (!File.Exists(mapPackageDirectoryPath))
            {
                Directory.CreateDirectory(mapPackageDirectoryPath);
            }
            var mapPackagePath = Path.Combine(mapPackageDirectoryPath,MAP_PACKAGE_NAME);
            if (!File.Exists(mapPackagePath))
            {
                _mapPackageFileStream = File.Create(mapPackagePath);
                var assembly = Assembly.GetExecutingAssembly();
                var mapPackageResourceName = ASSEMBLY_RESOURCES_PATH + MAP_PACKAGE_NAME;
                var mapPackageResource = assembly.GetManifestResourceStream(mapPackageResourceName);
                await mapPackageResource.CopyToAsync(_mapPackageFileStream);
                _mapPackageFileStream.Close();
            }
            _mapPackageFileStream = File.OpenRead(mapPackagePath);
            MapPackagePath = _mapPackageFileStream.Name;
            _mapPackageFileStream.Close();
            OnInitEnd?.Invoke(this, null);
        }

        public string MapPackagePath { get; private set; }
    }
}
