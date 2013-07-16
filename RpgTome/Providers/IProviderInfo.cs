using System.Collections.Generic;

namespace RpgTome.Providers
{
    public interface IProviderInfo<out T>
    {
        IEnumerable<string> Keys { get; }
        T GetProviderByName(string key);
    }
}