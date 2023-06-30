using Questions.TeamInterface;
using Questions.EmployeesManagement;

Console.WriteLine("Welcome to HackerRank Basic Solutions");
Console.WriteLine("Team Interface - [1]");
Console.WriteLine("Employees Management - [2]");

var chose = Console.ReadLine();

switch (chose)
{
    case "1":
        #region 1 - Team Interface

        Console.WriteLine("------------Team Interface------------");

        if (!typeof(Subteam).IsSubclassOf(typeof(TeamInterface)))
        {
            throw new Exception("Subteam class should inherit from Team class");
        }

        String str = Console.ReadLine();
        String[] strArr = str.Split();
        string initialName = strArr[0];
        int count = Convert.ToInt32(strArr[1]);
        Subteam teamObj = new Subteam(initialName, count);
        Console.WriteLine("Team " + teamObj.teamName + " created");

        str = Console.ReadLine();
        count = Convert.ToInt32(str);
        Console.WriteLine("Current number of players in team " +
        teamObj.teamName + " is " + teamObj.noOfPlayers);
        teamObj.AddPlayer(count);
        Console.WriteLine("New number of players in team " +
        teamObj.teamName + " is " + teamObj.noOfPlayers);

        str = Console.ReadLine();
        count = Convert.ToInt32(str);
        Console.WriteLine("Current number of players in team " +
        teamObj.teamName + " is " + teamObj.noOfPlayers);

        var res = teamObj.RemovePlayer(count);
        if (res)
        {
            Console.WriteLine("New number of players in team " +
            teamObj.teamName + " is " + teamObj.noOfPlayers);
        }
        else
        {
            Console.WriteLine("Number of players in team " +
            teamObj.teamName + " remains same");
        }
        str = Console.ReadLine();
        teamObj.ChangeTeamName(str);
        Console.WriteLine("Team name of team " + initialName + " changed to " +
        teamObj.teamName);

        #endregion
        break;

    case "2":
        #region 2 - Employees Management

        Console.WriteLine("\n");
        Console.WriteLine("------------Employees Management System------------");

        int countOfEmployees = int.Parse(Console.ReadLine());

        var employees = new List<Employee>();

        for (int i = 0; i < countOfEmployees; i++)
        {
            string strEmployee = Console.ReadLine();
            string[] strEmployeeArr = strEmployee.Split(' ');
            employees.Add(new Employee
            {
                FirstName = strEmployeeArr[0],
                LastName = strEmployeeArr[1],
                Company = strEmployeeArr[2],
                Age = int.Parse(strEmployeeArr[3])
            });
        }

        foreach (var emp in EmployeesManagement.AverageAgeForEachCompany(employees))
        {
            Console.WriteLine($"The average age for company {emp.Key} is {emp.Value}");
        }

        foreach (var emp in EmployeesManagement.CountOfEmployeesForEachCompany(employees))
        {
            Console.WriteLine($"The count of employees for company {emp.Key} is {emp.Value}");
        }

        foreach (var emp in EmployeesManagement.OldestAgeForEachCompany(employees))
        {
            Console.WriteLine($"The oldest employee of company {emp.Key} is {emp.Value.FirstName} {emp.Value.LastName} having age {emp.Value.Age}");
        }

        #endregion
        break;
    default:
        break;
}




