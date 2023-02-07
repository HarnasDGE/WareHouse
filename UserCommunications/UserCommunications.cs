using Lager.DataProvider;
using Lager.DataValidater;
using Lager.Entities;
using Lager.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Lager.UserCommunications
{
    public class UserCommunications : IUserCommunications
    {
        private readonly IApp _iApp;
        private readonly IDataValidater _dataValidater;

        private readonly int appWidth = 99;
        private readonly string appTittle = "Welcome in WareHouse v0.1";
        private readonly string appBottom = "Your Own Storage Assistant";
        public UserCommunications(IApp iApp, IDataValidater dataValidater)
        {
            _iApp = iApp;
            _dataValidater = dataValidater;
        }
        public void Menu()
        {
            do
            {
                MenuBuilder("What you want to do?", "E -Display all Employees!M - Display all Materials!S - Search!O - Order!A - Add");
                var userInput = Console.ReadLine();

                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                    if (userInput == "Q") break;

                    switch (userInput)
                    {
                        case "E":
                            this.DisplayAllEmployees();
                            break;
                        case "M":
                            this.DisplayAllMaterial();
                            break;
                        case "S":
                            this.Search();
                            break;
                        case "O":
                            this.OrderBy();
                            break;
                        case "A":
                            this.Add();
                            break;
                    }
                }
            } while (true);
        }

        private void Add()
        {
            do
            {
                Console.Clear();
                MenuBuilder("What you want add?", "E - Employees!M - Materials");
                var userInput = Console.ReadLine();
                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                    if (userInput == "Q") break;
                    switch (userInput)
                    {
                        case "E":
                            this.AddEmployeeMenu();
                            break;
                        case "M":
                            this.AddMaterialMenu();
                            break;
                    }
                }
            } while (true);
        }

        private void AddEmployeeMenu()
        {
            bool checkOut = false;
            var firstName = "";
            var lastName = "";
            var address = "";
            var phoneNumber = "";
            var email = "";
            var country = "";
            var dataBirthDay = "";
            var dataBegin = "";
            var hours = "";
            var price = "";
            int points = 0;
            do
            {
                MenuBuilder("Enter first name: ");

                var userInput = Console.ReadLine();

                if (userInput == "Q" || userInput == "q")
                {
                    checkOut = true;
                    break;
                }
                if (_dataValidater.CheckLengthAndNumber(15, userInput))
                {
                    firstName = userInput;
                    break;
                }
                else _dataValidater.ErrorMessage();
            } while (true);

            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter last name: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckLengthAndNumber(15, userInput))
                    {
                        lastName = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter address: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (userInput.Length < 25)
                    {
                        address = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter phone number(example. 0298278987): ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckNumber(11, userInput))
                    {
                        phoneNumber = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter email (user@example.com): ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckEmail(userInput))
                    {
                        email = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter country: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (userInput.Length < 25)
                    {
                        country = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter birthday(dd/MM/yyyy): ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckDate(userInput))
                    {
                        dataBirthDay = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter begin work(dd/MM/yyyy): ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckDate(userInput))
                    {
                        dataBegin = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter hours worked: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckNumber(5, userInput))
                    {
                        hours = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter points (minimum 1): ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckNumberOutInt(userInput) > 0)
                    {
                        points = _dataValidater.CheckNumberOutInt(userInput);
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter actual salary: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckNumber(8, userInput))
                    {
                        price = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }

            if (checkOut == false)
            {
                _iApp.AddEmployee(
                firstName,
                lastName,
                address,
                phoneNumber,
                email,
                country,
                dataBirthDay,
                dataBegin,
                hours,
                points,
                price);
            }
        }

        private void AddMaterialMenu()
        {
            var checkOut = false;
            var name = "";
            var country = "";
            var typeBox = "";
            double price = 0.00;
            int quantityBox = 0;
            float quantityPerBox = 0;
            do
            {
                MenuBuilder("Enter name of product: ");

                var userInput = Console.ReadLine();
                if (userInput == "Q" || userInput == "q")
                {
                    checkOut = true;
                    break;
                }
                if (_dataValidater.CheckLengthAndNumber(20, userInput))
                {
                    name = userInput;
                    break;
                }
                else _dataValidater.ErrorMessage();
            } while (true);

            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter product's country: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckLengthAndNumber(15, userInput))
                    {
                        country = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter box type: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckLength(10, userInput))
                    {
                        typeBox = userInput;
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter price for 1 piece/KG: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckNumberOutDouble(userInput) > 0)
                    {
                        price = _dataValidater.CheckNumberOutDouble(userInput);
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter count boxes/kg: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckNumberOutInt(userInput) > 0)
                    {
                        quantityBox = _dataValidater.CheckNumberOutInt(userInput);
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                do
                {
                    MenuBuilder("Enter count piece/kg in 1 Box: ");

                    var userInput = Console.ReadLine();
                    if (userInput == "Q" || userInput == "q")
                    {
                        checkOut = true;
                        break;
                    }
                    if (_dataValidater.CheckNumberOutFloat(userInput) > 0)
                    {
                        quantityPerBox = _dataValidater.CheckNumberOutFloat(userInput);
                        break;
                    }
                    else _dataValidater.ErrorMessage();
                } while (true);
            }
            if (checkOut == false)
            {
                _iApp.AddMaterial(
                    name,
                    country,
                    typeBox,
                    price,
                    quantityBox,
                    quantityPerBox);
            }
        }

        private void OrderBy()
        {
            do
            {
                Console.Clear();
                MenuBuilder("Display results by: ", "B - Best Employees (Points)!H - Best Employees (Hours)!A - Work Time (Ascending)!D - Work Time (Descending)! !M - The most Quantity Materials!G - The greatest value Materials ");
                var userInput = Console.ReadLine();
                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                    if (userInput == "Q") break;
                    switch (userInput)
                    {
                        case "B":
                            this.BestEmployeePoints();
                            break;
                        case "H":
                            this.BestEmployeeHours();
                            break;
                        case "A":
                            this.WorkTimeAscending();
                            break;
                        case "D":
                            this.WorkTimeDescending();
                            break;
                        case "M":
                            this.MostQuantityMaterials();
                            break;
                        case "G":
                            this.GreatestValueMaterials();
                            break;
                    }
                }
            } while (true);
        }

        private void GreatestValueMaterials()
        {
            var results = _iApp.OrderMaterialsByPrice();
            DisplayResult(results);
        }

        private void MostQuantityMaterials()
        {
            var results = _iApp.OrderMaterialsByQuantity();
            DisplayResult(results);
        }

        private void WorkTimeDescending()
        {
            var results = _iApp.OrderEmployeesByBeginDesc();
            DisplayResult(results);
        }

        private void WorkTimeAscending()
        {
            var results = _iApp.OrderEmployeesByBeginAsc();
            DisplayResult(results);
        }

        private void BestEmployeeHours()
        {
            List<string> Hours = _iApp.OrderEmployeesByHours();
            DisplayResult(Hours);
        }

        private void BestEmployeePoints()
        {
            List<string> Points= _iApp.OrderEmployeesByPoint();
            DisplayResult(Points);
        }

        private void Search()
        {
            do
            {
                Console.Clear();
                MenuBuilder("What you want to search?", "E - Employees!M - Materials");
                var userInput = Console.ReadLine();
                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                    if (userInput == "Q") break;
                    switch (userInput)
                    {
                        case "E":
                            this.SearchEmployee();
                            break;
                        case "M":
                            this.SearchMaterial();
                            break;
                    }
                }
            } while (true);
        }

        private void SearchEmployee()
        {
            do
            {
                Console.Clear();
                MenuBuilder("How you want search Employee?", "A - By ID!B - By Name!C - By Address");
                var userInput = Console.ReadLine();
                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                    if (userInput == "Q") break;
                    switch (userInput)
                    {
                        case "A":
                            this.SearchEmpByID();
                            break;
                        case "B":
                            this.SearchEmpByName();
                            break;
                        case "C":
                            this.SearchEmpByAddress();
                            break;
                    }
                }
            } while (true);
        }

        private void SearchEmpByAddress()
        {
            MenuBuilder("Enter Address to search: ");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput != "Q" || userInput != "q") this.DisplayResult(_iApp.GetEmployeeByAddress(userInput));
            }
            Console.ReadLine();
        }

        private void SearchEmpByName()
        {
            MenuBuilder("Enter Name to search: ");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput != "Q" || userInput != "q") this.DisplayResult(_iApp.GetEmployeeByName(userInput));
            }
            Console.ReadLine();
        }

        private void SearchEmpByID()
        {
            MenuBuilder("Enter ID to search: ");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput != "Q" || userInput != "q") this.MenuBuilder(_iApp.GetEmployeeById(userInput));
            }
            Console.ReadLine();
        }

        private void SearchMaterial()
        {
            do
            {
                Console.Clear();
                MenuBuilder("How you want search Material?", "A - By Prefix!B - By Country!C - By ID");
                var userInput = Console.ReadLine();
                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                    if (userInput == "Q") break;
                    switch (userInput)
                    {
                        case "A":
                            this.SearchMatByPrefix();
                            break;
                        case "B":
                            this.SearchMatByCountry();
                            break;
                        case "C":
                            this.SearchMatByID();
                            break;
                    }
                }
            } while (true);
        }

        private void SearchMatByID()
        {
            MenuBuilder("Enter ID to search: ");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput != "Q" || userInput != "q") this.MenuBuilder(_iApp.GetMaterialById(userInput));
            }
            Console.ReadLine();
        }

        private void SearchMatByCountry()
        {
            MenuBuilder("Enter country to search: ");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput != "Q" || userInput != "q") this.DisplayResult(_iApp.GetMaterialsByCountry(userInput));
            }
        }

        private void SearchMatByPrefix()
        {
            MenuBuilder("Enter prefix to search: ");
            var userInput = Console.ReadLine();
            if (userInput != null)
            {
                if (userInput != "Q" || userInput != "q") this.DisplayResult(_iApp.GetMaterialsByPrefix(userInput));
            }
        }

        private void DisplayAllEmployees()
        {
            this.DisplayResult(_iApp.GetAllEmployees());
        }

        private void DisplayAllMaterial()
        {
            this.DisplayResult(_iApp.GetAllMaterials());
        }

        public void MenuBuilder(string tittle, string options)
        {
            StringBuilder sb = new();
            sb.AppendLine(MenuTittleBuilder(appTittle));
            sb.AppendLine(MenuLineBuilder(" "));
            sb.AppendLine(MenuLineBuilder(tittle));
            sb.AppendLine(MenuLineBuilder(" "));
            var items = options.Split('!').ToList();
            foreach (var item in items)
            {
                sb.AppendLine(MenuLineBuilder(item));
            }
            sb.AppendLine(MenuLineBuilder(" "));
            sb.AppendLine(MenuLineBuilder("Q - Quit"));
            sb.AppendLine(MenuLineBuilder(" "));
            sb.AppendLine(MenuTittleBuilder(appBottom));

            Console.Clear();
            Console.WriteLine(sb.ToString());
        }

        public void MenuBuilder(string tittle)
        {
            StringBuilder sb = new();
            sb.AppendLine(MenuTittleBuilder(appTittle));
            sb.AppendLine(MenuLineBuilder(" "));
            sb.AppendLine(MenuLineBuilder(tittle));
            sb.AppendLine(MenuLineBuilder(" "));
            sb.AppendLine(MenuLineBuilder(" "));
            sb.AppendLine(MenuLineBuilder("Q - Quit"));
            sb.AppendLine(MenuLineBuilder(" "));
            sb.AppendLine(MenuTittleBuilder(appBottom));

            Console.Clear();
            Console.WriteLine(sb.ToString());
        }

        public string MenuLineBuilder(string option)
        {
            option = "= " + option;
            while (option.Length < appWidth - 1)
            {
                option = $"{option} ";
            }

            option = $"{option}=";

            return option;
        }

        public string MenuTittleBuilder(string tittle)
        {
            while (tittle.Length < appWidth)
            {
                if (tittle.Length < appWidth) tittle = $"{tittle}=";
                if (tittle.Length <= appWidth) tittle = "=" + tittle;
            }
            return tittle;
        }

        public string MenuChooseBuilder(string firstOption, string secondOption)
        {
            firstOption = $"= {firstOption}";
            secondOption = $"{secondOption} =";
            var freeSpace = appWidth / 2;
            firstOption = firstOption.PadRight(freeSpace, ' ');
            secondOption = secondOption.PadLeft(freeSpace, ' ');

            return firstOption + secondOption;
        }

        private void DisplayResult(List<string> values)
        {
            var skip = 0;
            var take = 10;
            List<string> pageValues;

            var countResult = values.Count;

            do
            {
                StringBuilder sb = new();
                sb.AppendLine(MenuTittleBuilder(appTittle));
                sb.AppendLine(MenuLineBuilder(" "));

                pageValues = values
                    .Skip(skip)
                    .Take(take)
                    .ToList();

                foreach (var item in pageValues)
                {
                    sb.AppendLine(MenuLineBuilder(item));
                }
                sb.AppendLine(MenuLineBuilder(" "));
                sb.AppendLine(MenuChooseBuilder($"Previus {take} - 'A'", $"Next {take} - 'S'"));
                sb.AppendLine(MenuTittleBuilder($"Enter number ID for skip!)"));
                sb.AppendLine(MenuTittleBuilder($"Results {skip} - {skip + take - 1} ({countResult - 1})"));
                Console.Clear();
                Console.WriteLine(sb.ToString());
                var userInput = Console.ReadLine();
                if (userInput != null)
                {
                    userInput = userInput.ToUpper();
                    if (userInput == "Q") break;
                    switch (userInput)
                    {
                        case "A":
                            skip -= take;
                            break;
                        case "S":
                            skip += take;
                            break;
                    }
                    if (_dataValidater.CheckNumberOutInt(userInput) > 0) skip = _dataValidater.CheckNumberOutInt(userInput);
                    if (skip < 0) skip = 0;
                    if (skip > countResult - take) skip = countResult - take;

                }
            } while (true);
        }
    }
}
