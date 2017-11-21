using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace m1
{
    /// <summary>
    ///Class1 的摘要说明
    /// </summary>
    public class Customer
    {
        public Customer()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private m1.FileLogger obj = new m1.FileLogger();
        public void Add()
        {

            try
            {
                // Database code goes here
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());//单一责任原则,一个类只做一件事情

                obj.Handle(ex.ToString());
            }
        }
    }
    //如果有一些SRP经验的朋友可能已经发现，其实这种解决方案并不能完全解决SRP的问题。因为try catch其实并不是Customer类需要关心的功能。

    // 在记录Log这一层，不同的语言和结构都会有一个类似Asp.Net中Global.asax或者WPF中App.xaml.cs这类文件可以集中来处理这些冒泡的错误，这样Customer类中便不会有TryCatch的方法。

    // 其实这个程序依然可以更好，也可以有更多的解决方案，但此文旨在使用足够简单的例子来用C#阐述SOLID，也希望可以不禁锢大家思维，有好的方案可以在下面回复和交流，来产出一个伟大的解决方案。

    public class Customer1
    {//
        private int _type;//会员类型
        public int type
        {
            get { return _type; }
            set { _type = value; }
        }
        //违反了Open Closed Principle 开放封闭原则
        public int getS()
        {//得到会员拆扣
            if (type == 1)//金卡
            {
                return 50;
            }
            else
            {
                return 100;
            }
        }
    }
    //  “嫌疑人”出现了，当我们再添加一个用户类型时，我们还需要添加修改if中的折扣逻辑，也就是我们需要修改Customer Class。

    //当我们一次次更改Customer Class，我们还需要确认之前的逻辑是没错的以及引用该Class的更多的逻辑也是没问题的，也就说需要一次又一次的测试。

    //那么问题来了，挖掘...不对，是如何来避免多次的“Modify”而带来的恶果呢，那就是“EXTENSION”(扩展).

    //当我们每次增加一个用户类型的时候，我们就增加一个Customer的扩展类，因此我们也就每次只需要测试新加的类


    class Bird
    {
        public virtual string Fly()
        {
            // Fly Logic
            return "bfly";
        }
    }

    class Penguin : Bird//企鹅类,不会飞,这里设计违反了LSP Liskov Substitution Principle 里氏替换原则
    {
        public override string Fly()
        {
            throw new Exception("Can Not Fly");
        }
    }
    class flyinchina : Bird
    {
        public override string Fly()
        {
            return "fly in china";
        }
    }
    class flyinus : Bird
    {
        public override string Fly()
        {
            return "fly in us";
        }
    }
    //  这时企鹅君便要崩溃了。风险就在别人使用你设计的类的时候并没有想到并非所有的子类都符合父类的要求。这便不符合LSP的原则了。
    //LSP俗语是：“老鼠的儿子会打洞。”，其实就是子类是和父类有相同的行为和状态，是可以完全替换父类的。这也是保护了OCP的开放扩展关闭修改的原则。
    //   前面例子更改方法可以采用父类高聚合，子类低耦合的原则来做，父类要精，子类可以采用接口实现的方法来进行扩展。
    //比如可以增加一个IFly的接口，实现该接口的子类便可以飞，而父类中便不再包含Fly方法。
    /// <summary>
    ///Customer2 的摘要说明
    /// </summary>
    public class Swallow : ifly, ieat
    {
        public Swallow()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string fly()
        {
            return "fly";
        }
        public string eat()
        {
            return "eat";
        }

    }
    public class Penguin2 : ieat
    {
        public Penguin2()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public string eat()
        {
            return "eat";
        }
    }
    interface ifly//这二个接口不能合在一起,
    {
        string fly();
    }
    interface ieat
    {
        string eat();

    }
    //ISP Interface Segregration Principle 接口分离原则
    //  所以这样就违反了接口分离规则，接口分离规则旨在使用多个特定功能的接口来避开通用接口造成的富余化。

    //也就是说 我们可以分离IBird为IFly和IEat，Swallow实现IFly和IEat，而呆呆的企鹅只需要实现IEat就好。

    //这样让程序的设计更加灵活，当需求改变的时候，我们要做的工作便小很多也风险少很多，也会发现更多的乐趣。


    // 创建实现看电视功能的接口
    public interface ITvProvider
    {
        void WatchTv();
    }

    // 创建一个TV的实体类，继承ITvProvider，实现其WatchTv方法。
    public class KonkaTv : ITvProvider
    {
        public void WatchTv()
        {
            // 实现看康佳电视功能的逻辑代码
        }
    }

    // 创建一个注入用的接口，实现类似容器/XML链接对象匹配的功能
    public interface ITvInjecter
    {
        void InjectTv(ITvProvider tvProvider);
    }

    // 创建一个看电视的控件，继承ITvInjecter（容器时则是继承类似IDepency这种可以拿到容器, 这里是不使用容器的方法）
    public class WatchTvControl : ITvInjecter
    {
        private ITvProvider _tvProvider;

        // 若使用容器，则在构造函数里既可以实现注入，不用手工来写注入方法。
        public void InjectTv(ITvProvider tvProvider)
        {
            _tvProvider = tvProvider;
        }

        public WatchTvControl()
        {
            // 注入完成后便可以使用其watchtv方法
            _tvProvider.WatchTv();
        }
    }

    public class Singleton{
        static Singleton s1;
        public String i = "";
        protected  Singleton(){
        }
        public static Singleton init(){
                if(s1==null){
                    s1 = new Singleton();
                }
                return s1;
        }
    }


}