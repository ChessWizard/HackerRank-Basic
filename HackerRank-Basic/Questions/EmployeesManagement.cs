using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.EmployeesManagement
{
    public class EmployeesManagement
    {
        /// <summary>
        /// Her bir şirkete ait çalışanların yaşlarının ortalamasını listeler
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var averageAges = employees.GroupBy(x => x.Company).Select(group => new
                                       {
                                          CompanyName = group.Key,// hangi veriye göre gruplanırsa o değer key olur
                                          AverageAge = Convert.ToInt32(Math.Round(group.Average(x => x.Age), 0)),// Hangi ondalığa en yakınsa oraya yuvarlanır
                                                                                                                 // ÖR: 2,4 -> 2 | 1,9 -> 2 olur
                                       }).ToDictionary(key => key.CompanyName,value => value.AverageAge);
            
            return averageAges;
        }

        /// <summary>
        /// Her bir şirkete ait çalışanların toplam sayısını listeler
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var countOfEmployees = employees.GroupBy(x => x.Company).Select(group => new
                                   {
                                      CompanyName = group.Key,
                                      CountOfEmployees = group.Count()
                                   }).ToDictionary(key => key.CompanyName, value => value.CountOfEmployees);

            return countOfEmployees;
        }

        /// <summary>
        /// Her bir şirkete ait en yaşlı çalışanları listeler
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            var oldestEmployees = employees.GroupBy(x => x.Company).Select(group => new
                                  {
                                      CompanyName = group.Key,
                                      OldestEmployee = group.OrderByDescending(x => x.Age).First(),
                                  }).ToDictionary(key => key.CompanyName, value => value.OldestEmployee);

            return oldestEmployees;
        }
    }

    /// <summary>
    /// Çalışan modeli
    /// </summary>
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
}