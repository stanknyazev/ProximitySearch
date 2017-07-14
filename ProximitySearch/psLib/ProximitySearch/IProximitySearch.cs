namespace psLib.ProximitySearch
{
    public interface IProximitySearch
    {
        int CountInstances(string keyword, string keywordTwo, int proximity);
        void SetSearcheableText(string text);
    }
}
