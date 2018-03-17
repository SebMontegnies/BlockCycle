
public class PisteCyclableModel
{
    public string name { get; set; }
    public string type { get; set; }
    public Feature[] features { get; set; }
}

public class Feature
{
    public string type { get; set; }
    public Geometry geometry { get; set; }
    public Properties properties { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public float[][] coordinates { get; set; }
}

public class Properties
{
    public string name { get; set; }
    public object image { get; set; }
    public object thumbnail { get; set; }
    public bool is_label { get; set; }
    public string label { get; set; }
}
