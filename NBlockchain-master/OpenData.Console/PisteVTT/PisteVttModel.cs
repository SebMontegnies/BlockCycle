
public class PisteVtt
{
    public string name { get; set; }
    public string type { get; set; }
    public FeatureVtt[] features { get; set; }
}

public class FeatureVtt
{
    public string type { get; set; }
    public GeometryVtt geometry { get; set; }
    public PropertiesVtt properties { get; set; }
}

public class GeometryVtt
{
    public string type { get; set; }
    public object[] coordinates { get; set; }
}

public class PropertiesVtt
{
    public string name { get; set; }
    public string image { get; set; }
    public string thumbnail { get; set; }
    public bool is_label { get; set; }
    public string label { get; set; }
}