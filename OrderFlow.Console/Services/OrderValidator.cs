using OrderFlow.Models;

namespace OrderFlow.Services;

public delegate bool ValidationRule(Order order, out string error);

public class OrderValidator
{
    private List<ValidationRule> _rules = new();
    private List<Func<Order, bool>> _funcRules = new();

    public void AddRule(ValidationRule rule) => _rules.Add(rule);
    public void AddFuncRule(Func<Order, bool> rule) => _funcRules.Add(rule);

    public List<string> ValidateAll(Order order)
    {
        List<string> errors = new();

        foreach (var rule in _rules)
            if (!rule(order, out string err))
                errors.Add(err);

        foreach (var rule in _funcRules)
            if (!rule(order))
                errors.Add("Func rule failed");

        return errors;
    }

    public static bool HasItems(Order o, out string err)
    {
        if (o.Items.Count == 0)
        {
            err = "No items";
            return false;
        }
        err = "";
        return true;
    }

    public static bool PositiveQuantity(Order o, out string err)
    {
        if (o.Items.Any(i => i.Quantity <= 0))
        {
            err = "Invalid quantity";
            return false;
        }
        err = "";
        return true;
    }

    public static bool MaxAmount(Order o, out string err)
    {
        if (o.TotalAmount > 10000)
        {
            err = "Too expensive";
            return false;
        }
        err = "";
        return true;
    }
}