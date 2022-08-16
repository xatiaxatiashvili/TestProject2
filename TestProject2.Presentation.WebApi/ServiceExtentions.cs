using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject2.Presentation.WebApi
{
    public static class ServiceExtensions
    {
        public static void AddThisLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
                //.AddFluentValidation();
            //AddFluentValidation(); ვწერ მაშინ როცა მინდა მეთოდში შესვლის დროს პარამეტრად რომ წერია createcommand.request მანდ მივიდეს და გაატაროს ვალიდაცია
            // თუ ამას არ დავწერ უნდა შევქმნა file validatebehavior რომელიც მედიატორში შესვლის დროს გამოიძახება send მეთოდზე
            //და exceptionhandlers გადააწვდის ერორებს


        }
    }
}
