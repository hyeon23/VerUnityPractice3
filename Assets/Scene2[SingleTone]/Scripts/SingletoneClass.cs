public class SingletoneClass
{
    //일반 클래스에서의 Singletone 사용법
    private SingletoneClass() { }

    private static SingletoneClass instance;
    public static SingletoneClass Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new SingletoneClass();
            }
            return instance;
        }
    }
}
