//http://www.ruanyifeng.com/blog/2012/10/javascript_module.html
var module1 = new Object({
    _count: 0, //私有
    m1: function () {
        //...
        return " world ";
    },
    m2: function (v) {
        //...
        return " hello " + v;
    }
});



//但是，这样的写法会暴露所有模块成员，内部状态可以被外部改写
// module2初始化
var module2 = (function (mod) {
    var _count = 0;
    mod._private = {};
    mod._private.a = "a"
    mod._private.b = "b"
    mod.m1 = function () {
        //...
        return "module2_m1";
    };
    mod.m2 = function () {
        //...
        return "module2_m2";
    };
    return mod;
})(module2 || {});
//放大模式
//一定要放在module2声明后,如果在前,那么会报错
var module2 = (function (mod) {
    mod.m3 = function () {
        //...
        return "module2_m3";
    };
    return mod;
})(module2);

var module2 = (function (my) {
    var _private = my._private = my._private || {},
        _seal = my._seal = my._seal || function () {
            delete my._private;
            delete my._seal;
            delete my._unseal;
        },
        _unseal = my._unseal = my._unseal || function () {
            my._private = _private;
            my._seal = _seal;
            my._unseal = _unseal;
        };
    // permanent access to _private, _seal, and _unseal
    return my;
} (module2 || {}));

//宽放大模式（Loose augmentation）
//在浏览器环境中，模块的各个部分通常都是从网上获取的，有时无法知道哪个部分会先加载。如果采用上一节的写法，
//第一个执行的部分有可能加载一个不存在空对象，这时就要采用"宽放大模式"。.

//如果放在module2定义前,这个新增的函数调用不了,也没用啊?
//有用,所有的定义都需要传入module2 || {},如果不传入,那么module2初始化会覆盖掉m4定义
//module2 没有初始化,那么就创建
var module2 = (function (mod) {
    //...
    var mpublic = mod._private.a;
    mod.m4 = function () {
        //...
        return mpublic;
        //return "module2_m4";
    };
    return mod;
})(module2 || {});


//六、输入全局变量
//独立性是模块的重要特点，模块内部最好不与程序的其他部分直接交互。
//为了在模块内部调用全局变量，必须显式地将其他变量输入模块。
var YAHOO = {};
YAHOO.name="testobj";
var module3 = (function ($, YAHOO) {
    //...
      
})(jQuery, YAHOO);
//上面的module1模块需要使用jQuery库和YUI库，就把这两个库（其实是两个模块）当作参数输入module1。这样做除了保证模块的独立性，还使得模块之间的依赖关系变得明显

//http://www.jb51.net/article/58024.htm
//匿名闭包
//闭包内不声明YAHOO ,那么YAHOO指定外层声明的YAHOO
//闭包内声明了,修改只是修改内部局部变量,对外部的YAHOO没有关系
//闭包内要使用外部,按传参的行式,这样比较直观
//函数传参,如果是对象/数组是传址,如果是值那么是传值
var myvalue = "testvalue";
(function (exvalue,exobj) {
    //var YAHOO={};YAHOO.name="goo";
//    alert(exvalue)
//    alert(exobj.name)
//    exvalue="123value";
//    exobj.name="123obj";
} (myvalue,YAHOO))
//alert(myvalue);
//alert(YAHOO.name);

//和上面的模块化写法是一样的,注意需要返回值,其实本质都是一个对象
var MODULE = (function () {
    var my = {},
        privateVariable = 1;
    function privateMethod() {
        // ...
    }
    my.moduleProperty = 1;
    my.moduleMethod = function () {
        // ...
    };
    return my;
}());

//紧放大模式
//宽放大模式非常不错，但它也会给你的模块带来一些限制。最重要的是，你不能安全地覆盖模块的属性。
//你也无法在初始化的时候，使用其他文件中的属性（但你可以在运行的时候用）。紧放大模式包含了一个加载的顺序序列，并且允许覆盖属性。
//这儿是一个简单的例子（放大我们的原始MODULE）：
//复制代码 代码如下:

var MODULE = (function (my) {
    var old_moduleMethod = my.moduleMethod;
    my.moduleMethod = function () {
        // method override, has access to old through old_moduleMethod...
    };
    return my;
}(MODULE));
//    我们在上面的例子中覆盖了MODULE.moduleMethod的实现，但在需要的时候，可以维护一个对原来方法的引用。


//克隆与继承
//复制代码 代码如下:

var MODULE_TWO = (function (old) {
    var my = {},
        key;
    for (key in old) {
        if (old.hasOwnProperty(key)) {
            my[key] = old[key];
        }
    }
    var super_moduleMethod = old.moduleMethod;
    my.moduleMethod = function () {
        // override method on the clone, access to super through super_moduleMethod
    };
    return my;
}(MODULE));
//这个模式可能是最缺乏灵活性的一种选择了。它确实使得代码显得很整洁，但那是用灵活性的代价换来的。
//正如我上面写的这段代码，如果某个属性是对象或者函数，它将不会被复制，而是会成为这个对象或函数的第二个引用。
//修改了其中的某一个就会同时修改另一个（译者注：因为它们根本就是一个啊！）。这可以通过递归克隆过程来解决这个对象克隆问题，
//但函数克隆可能无法解决，也许用eval可以解决吧。因此，我在这篇文章中讲述这个方法仅仅是考虑到文章的完整性。



//跨文件私有变量
//把一个模块分到多个文件中有一个重大的限制：每一个文件都维护了各自的私有变量，并且无法访问到其他文件的私有变量。
//但这个问题是可以解决的。这里有一个维护跨文件私有变量的、宽放大模块的例子：
//复制代码 代码如下:

//私有变量,只有在定义的时候有用,在运行的时候没有必要访问,如果需要访问那就是公有的了
//所以在定义的时候将所有私有变量放在一个对象下,在完成定义后,删掉这个对象,就能阻止外部程序访问.
var MODULE = (function (my) {
    var _private = my._private = my._private || {},
        _seal = my._seal = my._seal || function () {
            delete my._private;
            delete my._seal;
            delete my._unseal;
        },
        _unseal = my._unseal = my._unseal || function () {
            my._private = _private;
            my._seal = _seal;
            my._unseal = _unseal;
        };
    // permanent access to _private, _seal, and _unseal
    return my;
}(MODULE || {}));
//所有文件可以在它们各自的_private变量上设置属性，并且它理解可以被其他文件访问。一旦这个模块加载完成，
//应用程序可以调用MODULE._seal()来防止外部对内部_private的调用。如果这个模块需要被重新放大，
//在任何一个文件中的内部方法可以在加载新的文件前调用_unseal()，并在新文件执行好以后再次调用_seal()。
//我如今在工作中使用这种模式，而且我在其他地方还没有见过这种方法。我觉得这是一种非常有用的模式，
//很值得就这个模式本身写一篇文章。


//子模块
//我们的最后一种进阶模式是显而易见最简单的。创建子模块有许多优秀的实例。这就像是创建一般的模块一样：
//复制代码 代码如下:

MODULE.sub = (function () {
    var my = {};
    // ...
    return my;
}());
//虽然这看上去很简单，但我觉得还是值得在这里提一提。子模块拥有一切一般模块的进阶优势，包括了放大模式和私有化状态