// See https://aka.ms/new-console-template for more information
using LinqApp;

var studs = Student.Generate();
var groups = Group.GetGroups();

foreach (var g in groups)
{
  //  Console.WriteLine(g);
}


//var expr = studs.Where(s => s.Group == "6310").TakeLast(3);

//var expr = studs.OrderByDescending(s => s.Group)
//    .ThenBy(s => s.Marks.Average());

//var expr = studs.Where(s=>s.Group=="6310").SelectMany(s => s.Marks);

//Console.WriteLine(studs.OrderByDescending(s => s.Marks.Average()).Last());

//Console.WriteLine(studs.FirstOrDefault(s => s.Group == "6312"));


//var expr = studs.Select(s => new { s.Group, s.Name, Len = s.Name.Length });


//var expr = studs.GroupBy(s => s.idGroup)
//    .Select(g=>new { Gr = g.Key, Count = g.Count(), 
//        max = g.Max(s=> s.Marks.Average()), elems = g }) ;


//foreach (var st in expr)
//{
//    Console.WriteLine(st);
//    foreach (var g in st.elems)
//        { Console.WriteLine("      "+g.ToString()); }
//}



var expr = studs.Join(groups, s => s.idGroup, g => g.Id,
     (s, g) => new { StName = s.Name, GrName =  g.Name, Faculty = g.Faculty, AverMarks =  s.Marks.Average() });

var expr2 = groups.Join(studs,  g => g.Id, s => s.idGroup,
     (g, s) => new { StName = s.Name, GrName = g.Name, Faculty = g.Faculty, AverMarks = s.Marks.Average() });


foreach (var st in expr.GroupBy(s=>s.Faculty))
{
    Console.WriteLine($"{st.Key} {st.Count()}");
}