
using Lager;
using Lager.DataProvider;
using Lager.DataValidater;
using Lager.Entities;
using Lager.Repositories;
using Lager.UserCommunications;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, FileRepository<Employee>>();
services.AddSingleton<IRepository<Material>, FileRepository<Material>>();
services.AddSingleton<IMaterialsProvider, MaterialsProvider>();
services.AddSingleton<IEmployeeProvider, EmployeeProvider>();
services.AddSingleton<IUserCommunications, UserCommunications>();
services.AddSingleton<IDataValidater, DataValidater>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
var userCommunications = serviceProvider.GetService<IUserCommunications>()!;

app.Run();
userCommunications.Menu();

