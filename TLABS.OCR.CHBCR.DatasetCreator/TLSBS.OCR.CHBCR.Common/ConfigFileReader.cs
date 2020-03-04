using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TLABS.OCR.CHBCR.Common
{
    public class ConfigFileReader
    {
        Dictionary<string, string> Configs = new Dictionary<string, string>();
        string ConfigFilePath = string.Empty;

        public ConfigFileReader(string config_file)
        {
            this.ConfigFilePath = config_file;
            Load(config_file);
        }

        void Load(string config_file)
        {
            if (File.Exists(config_file))
            {
                var lines = File.ReadAllLines(config_file);

                foreach (string line in lines)
                {
                    if (line.StartsWith("#") || line.StartsWith("!") || line.StartsWith("@"))
                        continue;

                    string tl = line.Trim();
                    if (string.IsNullOrEmpty(tl)) continue;

                    int sp = tl.IndexOf(' ');
                    if (sp < 0) continue;

                    var key = tl.Substring(0, sp).Trim();
                    var val = tl.Substring(sp).Trim();

                    if (!this.Configs.ContainsKey(key))
                    {
                        this.Configs.Add(key, val);
                    }
                    else
                    {
                        this.Configs[key] = val;
                    }
                }
            }
        }

        public void Reload()
        {
            Configs.Clear();
            Load(this.ConfigFilePath);
        }

        public bool HasConfig(string config)
        {
            return this.Configs.ContainsKey(config);
        }

        public string GetConfig(string config)
        {
            if (this.Configs.ContainsKey(config))
            {
                return this.Configs[config];
            }

            return string.Empty;
        }
    }
}
