using System.Collections.Generic;

public class GradeSchool
{
    private readonly HashSet<string> _allStudents= new();
    private SortedDictionary<int, List<string>> _studentsByGrades = new();

    public bool Add(string student, int grade)
    {
        if (_allStudents.Contains(student)) return false;

        _allStudents.Add(student);

        if (_studentsByGrades.TryGetValue(grade, out var value)) { value.Add(student); value.Sort(); }
        else _studentsByGrades.Add(grade, new List<string> { student });

        return true;
    }

    public IEnumerable<string> Roster()
    {
        List<string> output = new();

        foreach(var studentsByGrade in _studentsByGrades) { output.AddRange(studentsByGrade.Value); }

        return output;
    }

    public IEnumerable<string> Grade(int grade) => _studentsByGrades.TryGetValue(grade, out var value) ? value : new List<string>();
}