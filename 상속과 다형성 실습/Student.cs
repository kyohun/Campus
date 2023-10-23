using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 상속과_다형성_실습
{
    internal class Student
    {
        readonly int sn;
        string name;

        public string GetName()
        {
               return name;
        }
        const int init_iq = 80;
        const int min_iq = 60;
        const int max_iq = 200;

        public string stutype;
        public string place;

        public string CStudent; //도전적인 학생
        public string MStudent; //보수적인 학생
        public string PStudent; //수동적인 학생


        int iq;
        public int IQ
        {
            get
            {
                return iq;
            }
            set
            {
                if (value < min_iq)
                {
                    value = min_iq;
                }
                if (value > max_iq)
                {
                    value = max_iq;
                }
                iq = value;
            }
        }
        int hp;
        const int init_hp = 50;
        const int min_hp = 0;
        const int max_hp = 100;
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                if (value < min_hp)
                {
                    value = min_hp;
                }
                if (value > max_hp)
                {
                    value = max_hp;
                }
                hp = value;
            }
        }
        int cp;
        const int init_cp = 0;
        const int min_cp = 0;
        const int max_cp = 100;
        public int CP
        {
            get
            {
                return cp;
            }
            set
            {
                if (value < min_cp)
                {
                    value = min_cp;
                }
                if (value > max_cp)
                {
                    value = max_cp;
                }
                cp = value;
            }
        }
        static int last_sn;
        public Student(string name)
        {
            this.name = name;
            last_sn++;
            this.sn = last_sn;
            CP = init_cp;
            HP = init_hp;
            IQ = init_iq;
        }
        public void ListenLecture() //판서강의
        {
            IQ += 5;
            HP -= 4;
            CP -= 1;
            if(stutype == CStudent)
            {
                IQ += 1;
                CP += 1;
            }
            //판서강의가 진행되면 도전적인 학생은 질문한다(iq와 cp가 1올라간다.)
        }
        public void presentation() //발표수업
        {
            CP += 3;
            HP -= 2;
        }
        public void ListenSeminar() //세미나
        {
            IQ += 5;
            HP -= 4;
        }
        public void ReadBook() //책 읽기
        {
            IQ += 2;
            CP += 2;
            if(stutype == CStudent)
            {
                CP += 1;
            }
            //도전적인 학생은 추가로 cp1올라감
        }
        public void WatchingTV() //TV시청
        {
            HP -= 2;
            if(stutype == MStudent)
            {
                CP -= 1;
            }
            //보수적인 학생은 추가로 cp1내려감
        }
        public void Sleep()  //잠자기
        {
            HP += 2;
            if(stutype == PStudent)
            {
                HP -= 1;
                IQ += 1;
            }
            //수동적인 학생은 잠자면서 잠꼬대(hp1내려가고 iq1올라감)
        }
        public override string ToString()
        {
            return string.Format("번호:{0} 이름:{1} 성격:{2}, 위치:{3}", sn, name, stutype, place);
        }

    }

}
