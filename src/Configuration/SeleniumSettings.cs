namespace SeleniumExample.Configuration
{
    public class SeleniumSettings
    {
        public string Browser { get; set; }
        public string BrowserVersion { get; set; }
        public string Platform { get; set; }
        public bool Headless { get; set; }
        public SeleniumGrid SeleniumGrid { get; set; }
        public Capabilities Capabilities { get; set; }
    }

    public class SeleniumGrid
    {
        public bool Enabled { get; set; }
        public string Url { get; set; }
    }

    public class Capabilities
    {
        public bool AcceptSslCerts { get; set; }
        public string PageLoadStrategy { get; set; }

        public Dictionary<string,string> Caps { get; set; }
        public MobileEmulation MobileEmulation { get; set; }
        public SauceOptions SauceOptions { get; set; }
    }

    public class MobileEmulation
    {
        public bool Enable { get; set; }
        public string DeviceName { get; set; }
        public DeviceMetrics DeviceMetrics { get; set; }
        public string UserAgent { get; set; }
    }

    public class DeviceMetrics
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public double PixelRatio { get; set; }
    }

    public class SauceOptions
    {
        public string Username { get; set; }
        public string AccessKey { get; set; }
        public string Name { get; set; }
        public string Build { get; set; }
        public List<string> Tags { get; set; }
    }
}
