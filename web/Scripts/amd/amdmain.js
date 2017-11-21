//加载非AMD的js没实现
requirejs.config({
    //By default load any module IDs from js/lib
    baseUrl: 'Scripts/amd',
    //except, if the module ID starts with "app",
    //load it from the js/app directory. paths
    //config is relative to the baseUrl, and
    //never includes a ".js" extension since
    //the paths config could be for a directory.
    paths: {
        jqueryRename: '../jquery/jquery-1.11.3.min',
        myconfig: '..'

    } 
});

 

//http://www.requirejs.cn/
//http://www.cnblogs.com/snandy/archive/2012/05/22/2513652.html
//jquery模块从1.7后才开始支持AMD,所以要使用1.7后的版本 且模块名一定是[jquery]
//在加载的时候,会自动加上后缀.js,所以不要在模块名里写.js
requirejs(['jqueryRename', 'amdmath', 'myconfig/testamd/amdabs' ], function ($, math, abs) {
    //alert($().jquery);
    alert(math.add(1, 1));
    alert(abs.abs(12, 0.5));    
});

 
 