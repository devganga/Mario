using Mario.Infrastructure.Identity;

namespace Mario.Web.Endpoints;
public class Users : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapIdentityApi<ApplicationUser>();
    }
}
