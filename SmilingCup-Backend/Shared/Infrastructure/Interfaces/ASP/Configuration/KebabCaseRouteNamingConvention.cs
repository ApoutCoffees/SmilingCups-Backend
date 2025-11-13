using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using SmilingCup_Backend.Shared.Infrastructure.Interfaces.Asp.Configuration.Extensions;
using System.Linq;


namespace SmilingCup_Backend.Shared.Infrastructure.Interfaces.Asp.Configuration;

public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        string kebabCaseName = controller.ControllerName.ToKebabCase();

        foreach (var selector in controller.Selectors.ToList())
        {
            if (selector.AttributeRouteModel != null)
            {
                selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template?
                    .Replace("[controller]", kebabCaseName);

                ApplyKebabCaseToActions(controller, kebabCaseName);
            }
        }
    }
    
    private static void ApplyKebabCaseToActions(ControllerModel controller, string controllerKebabCaseName)
    {
        foreach (var action in controller.Actions)
        {
            foreach (var selector in action.Selectors.ToList())
            {
                var originalRoute = selector.AttributeRouteModel;
                if (originalRoute == null) continue;

                var kebabActionName = action.ActionName.ToKebabCase();
                
                originalRoute.Template = originalRoute.Template?
                    .Replace("[controller]", controllerKebabCaseName)
                    .Replace("[action]", kebabActionName);
            }
        }
    }
}