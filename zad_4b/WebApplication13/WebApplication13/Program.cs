using WebApplication13.Data;

namespace WebApplication13
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// ��������� ������� � ��������� ������������
			builder.Services.AddSingleton<IDataServise, CarDataServise>();

			// ��������� ��������� ������������
			builder.Services.AddControllersWithViews();

			// ��������� ��������� CORS
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

			// ������������ ��������� ��������� ��������
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts(); // �������� HSTS ��� ����������
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			// ���������� CORS ����� ��������������
			app.UseCors("AllowAll");

			app.UseAuthorization();

			// ���������� ������� �� ���������
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=CarServise}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
