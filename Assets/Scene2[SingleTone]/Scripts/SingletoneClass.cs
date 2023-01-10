public class SingletoneClass
{
    //�Ϲ� Ŭ���������� Singletone ����
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
