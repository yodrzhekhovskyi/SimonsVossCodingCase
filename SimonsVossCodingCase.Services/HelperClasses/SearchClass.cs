namespace SimonsVossCodingCase.Services.HelperClasses;

public class SearchCriteria<T>
{
    public string PropName { get; set; } = string.Empty;
    public Func<T, bool> Predicate { get; set; } = (T) => true;

    public int Weight { get; set; } = 0;
    public bool ShouldGoDeeper { get; set; } = false;

    public int TransitiveWeight { get; set; } = 0;
}
