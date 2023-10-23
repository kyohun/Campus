using EHLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 상속과_다형성_실습
{
    internal class CampusLife           //싱글톤
    {
        private static CampusLife Instance;
        private CampusLife() { }

        public static CampusLife getInstance()
        {
            if (Instance == null)
            {
                Instance = new CampusLife();
            }
            return Instance;
        }
      Student[] stues;
      public void InIt()
        {
            int num = EH.InputNum("최대 학생 수:");
            stues = new Student[num];
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("{0} 번째 학생 이름:", i + 1);
                string name = Console.ReadLine();
                stues[i] = new Student(name);

                Console.WriteLine("학생 유형을 선택하세요 (C: 도전적인 학생, M: 보수적인 학생, P: 수동적인 학생):");
                string userType = Console.ReadLine().ToUpper();
                switch (userType)
                {
                    case "C":
                        stues[i].stutype = "도전적인 학생";
                        break;
                    case "M":
                        stues[i].stutype = "보수적인 학생";
                        break;
                    case "P":
                        stues[i].stutype = "수동적인 학생";
                        break;
                    default:
                        Console.WriteLine("유효하지 않은 학생 유형입니다. 기본값으로 설정됩니다.");
                        stues[i].stutype = "도전적인 학생"; // 기본값 설정
                        break;
                }
                stues[i].place = "캠퍼스";
            }
        }
        public void Run()
        {
            ConsoleKey key = ConsoleKey.NoName;
            while ((key = SelectMeun()) != ConsoleKey.Escape)
            {
                switch (key)
                {
                    case ConsoleKey.F1: MoveStudent(); break;
                    case ConsoleKey.F2: MoveFocus(); break;
                    case ConsoleKey.F3: ViewAll(); break;
                    default: Console.WriteLine("잘못 선택하였습니다."); break;
                }
                Console.WriteLine("아무 키나 누르세요.");
                Console.ReadKey(true);
            }
        }
        private void MoveStudent()
        {
            Student selectedStudent = SelectStudent("학생 이동할 학생 선택:");
            if (selectedStudent == null)
            {
                Console.WriteLine("잘못된 학생 선택입니다.");
                return;
            }

            Console.WriteLine("이동할 장소를 선택하세요:");
            Console.WriteLine("1. 강의실");
            Console.WriteLine("2. 도서관");
            Console.WriteLine("3. 기숙사");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    selectedStudent.place = "강의실";
                    Console.WriteLine("{0} 학생이 강의실로 이동했습니다.", selectedStudent.GetName());
                    break;
                case "2":
                    selectedStudent.place = "도서관";
                    Console.WriteLine("{0} 학생이 도서관으로 이동했습니다.", selectedStudent.GetName());
                    break;
                case "3":
                    selectedStudent.place = "기숙사";
                    Console.WriteLine("{0} 학생이 기숙사로 이동했습니다.", selectedStudent.GetName());
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 이동하지 않았습니다.");
                    break;
            }
        }
        private void MoveFocus()
        {
            Console.WriteLine("캠퍼스 활동 선택:");
            Console.WriteLine("1. 강의실 활동");
            Console.WriteLine("2. 도서관 활동");
            Console.WriteLine("3. 기숙사 활동");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CampusClassroomActivities();
                    break;
                case "2":
                    CampusLibraryActivities();
                    break;
                case "3":
                    CampusDormitoryActivities();
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }
        private void CampusClassroomActivities()
        {
            Console.WriteLine("강의실 활동 선택:");
            Console.WriteLine("1. 판서 강의");
            Console.WriteLine("2. 발표 수업");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    foreach (Student student in stues.Where(s => s.place == "강의실"))
                    {
                        student.ListenLecture();
                        Console.WriteLine($"{student.GetName()} 끄적 끄적");
                    }
                    break;
                case "2":
                    
                    Student presentingStudent = SelectStudent_lec("발표할 학생:");
                    if (presentingStudent != null)
                    {
                        presentingStudent.presentation();
                        Console.WriteLine($"{presentingStudent.GetName()} 이러쿵 저러쿵");
                        foreach (Student student in stues.Where(s => s.place == "강의실" && s != presentingStudent))
                        {
                            student.ListenSeminar();
                            Console.WriteLine($"{student.GetName()} 초롱 초롱...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못 선택하였습니다.");
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }

        private void CampusLibraryActivities()
        {
            Console.WriteLine("도서관 활동 선택:");
            Console.WriteLine("1. 세미나 진행");
            Console.WriteLine("2. 책 읽기");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    Student seminarStudent = SelectStudent_lib("세미나를 진행할 학생:");
                    if (seminarStudent != null)
                    {
                        seminarStudent.ListenSeminar();
                        Console.WriteLine($"{seminarStudent.GetName()} 세미나 진행 중...");
                        foreach (Student student in stues.Where(s => s.place == "도서관" && s != seminarStudent))
                        {
                            student.ListenSeminar();
                            Console.WriteLine($"{student.GetName()} 초롱 초롱...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못 선택하였습니다.");
                    }
                    break;
                case "2":
                    Student readingStudent = SelectStudent_lib("책을 읽을 학생:");
                    if (readingStudent != null)
                    {
                        readingStudent.ReadBook();
                        Console.WriteLine($"{readingStudent.GetName()} 쓰슥~ 쓰슥~");
                    }
                    else
                    {
                        Console.WriteLine("아무도 안 읽는군요.");
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }

        private void CampusDormitoryActivities()
        {
            Console.WriteLine("기숙사 활동 선택:");
            Console.WriteLine("1. TV 시청");
            Console.WriteLine("2. 잠자기");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                        Student tvStudent = SelectStudent_dor("TV 볼 학생:");
                            if (tvStudent != null)
                            {
                                tvStudent.WatchingTV();
                                Console.WriteLine($"{tvStudent.GetName()} 으히히리~");
                            }
                            else
                            {
                                Console.WriteLine("아무도 없네요.");
                            }
                    break;
                case "2":
                    foreach (Student student in stues.Where(s => s.place == "기숙사"))
                    {
                        student.Sleep();
                        Console.WriteLine($"{student.GetName()} zz...");
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }
        }
        private void ViewAll()
        {
            Console.WriteLine("전체 보기");
            foreach (Student stu in stues)
            {
                ViewStuInfo(stu);
            }
        }

        private void ViewStuInfo(Student stu)
        {
            Console.WriteLine("*** {0}", stu);
            Console.WriteLine("   IQ:{0} HP:{1} CP:{2}", stu.IQ, stu.HP, stu.CP);
        }
        private Student SelectStudent(string msg) //일반
        {
            Console.WriteLine(msg);
            foreach (Student stu in stues)
            {
                Console.WriteLine(stu);
            }
         
                int num = EH.InputNum("번호:");
            if ((num > 0) && (num <= stues.Length))
            {
                return stues[num - 1];
            }
            return null;
        }
        private Student SelectStudent_lec(string msg) //강의실
        {
            Console.WriteLine(msg);
            foreach (Student stu in stues.Where(s => s.place == "강의실"))
            {
                Console.WriteLine(stu);
            }
            int num = EH.InputNum("번호:");
            if ((num > 0) && (num <= stues.Length))
            {
                return stues[num - 1];
            }
            return null;
        }
        private Student SelectStudent_lib(string msg) //도서관
        {
                Console.WriteLine(msg);
                foreach (Student stu in stues.Where(s => s.place == "도서관"))
                {
                    Console.WriteLine(stu);
                }
                int num = EH.InputNum("번호:");
                if ((num > 0) && (num <= stues.Length))
                {
                    return stues[num - 1];
                }
            return null;
        }
        private Student SelectStudent_dor(string msg) //기숙사
        {
            Console.WriteLine(msg);
            foreach (Student stu in stues.Where(s => s.place == "기숙사"))
            {
                Console.WriteLine(stu);
            }
                int num = EH.InputNum("번호:");
                if ((num > 0) && (num <= stues.Length))
                {
                    return stues[num - 1];
                }
            return null;
        }


        private ConsoleKey SelectMeun()
        {
            Console.Clear();
            Console.WriteLine("===    메뉴   ===");
            Console.WriteLine("* F1: 학생 이동");
            Console.WriteLine("* F2: 초점 이동");
            Console.WriteLine("* F3: 전체 정보 보기");
            Console.WriteLine("* ESC: 프로그램 종료");
            return Console.ReadKey(true).Key;
        }
    }
}
