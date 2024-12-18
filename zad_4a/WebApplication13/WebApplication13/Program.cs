using WebApplication13.Data;

namespace WebApplication13
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Добавляем сервисы в контейнер зависимостей
			builder.Services.AddSingleton<IDataServise, CarDataServise>();

			// Добавляем поддержку контроллеров
			builder.Services.AddControllersWithViews();

			// Добавляем поддержку CORS
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", policy =>
				{
					policy.AllowAnyOrigin()
						  .AllowAnyMethod()
						  .AllowAnyHeader();
				});
			});

			var app = builder.Build();

			// Конфигурация конвейера обработки запросов
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts(); // Включаем HSTS для продакшена
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			// Применение CORS перед маршрутизацией
			app.UseCors("AllowAll");

			app.UseAuthorization();

			// Определяем маршрут по умолчанию
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=CarServise}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
