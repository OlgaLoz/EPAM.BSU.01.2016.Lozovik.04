using System;
using System.Collections.Generic;

namespace Task3
{
    public interface IVisitor
    {
        void Add(Student student);
        void Delete(Student student);
    }

    public class Student
    {
        public string Name { get; }

        public Student(string name)
        {
            Name = name;
        }

        public void EnrollInACourse(IVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            visitor.Add(this);
        }

        public void SignOffOnACourse(IVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            visitor.Delete(this);
        }
    }

    public class Teacher
    {
        public string Name { get; }

        public Teacher(string name)
        {
            Name = name;
        }

        public Course CreateCourse(string name)
        {
            return new Course(name, this);
        }

        public void AddMark(Archive archive, Mark mark)
        {
            if (mark == null)
            {
                throw new ArgumentNullException(nameof(mark));
            }
            archive.Add(mark);
        }

        public void DeleteMark(Archive archive, int index)
        {
            archive.DeleteAt(index);
        }

    }

    public class Course : IVisitor
    {
        public string Name { get; }

        public Teacher Teacher { get; }

        public List<Student> Students {get;}
     
        public Course(string name, Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            Name = name;
            Teacher = teacher;
            Students = new List<Student>();
        }

        public void Add(Student student)
        {
            Students.Add(student);   
        }

        public void Delete(Student student)
        {
            if (!Students.Remove(student))
            {
                throw new Exception("You are not in the course!");
            }           
        }
    }

    public class Mark
    {
        public int Value { get; }

        public Course Course { get; }

        public Student Student { get; }

        public Mark(int value, Course course, Student student)
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentException("Makr must be in the interval from 1 to 10!");
            }

            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            Value = value;
            Course = course;
            Student = student;
        }
    }

    public sealed class Archive
    {
        private static readonly Lazy<Archive> instance = new Lazy<Archive>(()=>new Archive());

        private readonly int capasity = 10;

        private Mark[] items;

        public static Archive Instance
        {
            get { return instance.Value; }
        }

        public int Count { get; private set; }

        private Archive()
        {
            items = new Mark[capasity];
            Count = 0;
        }

        public Mark this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                return items[index];
            }
        }

        public void Add(Mark element)
        {
            if (Count == items.Length)
            {
                var newItems = new Mark[items.Length + capasity];
                items.CopyTo(newItems, 0);
                items = newItems;
            }

            items[Count] = element;
            Count++;
        }

        public void DeleteAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();

            for (int i = index; i < Count - 1; ++i)
                items[i] = items[i + 1];
            Count--;

        }

    }

}
