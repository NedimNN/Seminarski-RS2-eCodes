using eCodes.Services;
using eCodes.Services.Database;
using eCodes.Services.HelperMethods;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;


public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public IUsersService _usersService { get; set; }
    public IBuyersService _buyersService { get; set; }
    public IEmployeeService _employeesService { get; set; }
    public ISellersService _sellersService { get; set; }

 
    public BasicAuthenticationHandler(
        IUsersService usersService,
        IBuyersService buyersService,
        IEmployeeService employeeService,
        ISellersService sellersService,
        IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
    {
        _usersService = usersService;
        _buyersService = buyersService;
        _employeesService = employeeService;
        _sellersService = sellersService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {

        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing authentication header! ");
        }

        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        var credentialsBytes = Convert.FromBase64String(authHeader.Parameter);
        var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(":");

        var username = credentials[0];
        var password = credentials[1];

        var user = _usersService.Login(username, password);
        var buyer = _buyersService.Login(username, password);
        var employee = _employeesService.Login(username, password);
        var seller = _sellersService.Login(username, password);


        if (user == null && buyer == null && employee == null && seller == null )
            return AuthenticateResult.Fail("Wrong Username or Password ! ");
       
        if(user != null)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier,username),
            new Claim(ClaimTypes.Name, _usersService.GetPersonName(user.PersonId))
            };

            foreach (var role in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            LoginHelper.ID = user.UserId;
            LoginHelper.AccountType = "User";

            return AuthenticateResult.Success(ticket);

        }
        else if(buyer != null)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier,username),
            new Claim(ClaimTypes.Name, _buyersService.GetPersonName(buyer.PersonId)),
            new Claim(ClaimTypes.Role, "Buyer")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            LoginHelper.ID = buyer.BuyerId;
            LoginHelper.AccountType = "Buyer";


            return AuthenticateResult.Success(ticket);

        }
        else if (employee != null)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier,username),
            new Claim(ClaimTypes.Name, _employeesService.GetPersonName(employee.PersonId)),
            new Claim(ClaimTypes.Role, "Employee")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            LoginHelper.ID = employee.EmployeeId;
            LoginHelper.AccountType = "Employee";


            return AuthenticateResult.Success(ticket);

        }
        else if (seller != null)
        {
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.NameIdentifier,username),
            new Claim(ClaimTypes.Name, _sellersService.GetPersonName(seller.PersonId)),
            new Claim(ClaimTypes.Role, "Seller")
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            LoginHelper.ID = seller.SellerId;
            LoginHelper.AccountType = "Seller";


            return AuthenticateResult.Success(ticket);

        }

        return AuthenticateResult.Fail("Invalid login ! ");

    }
}