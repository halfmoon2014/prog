<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="extend_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script language="javascript">
        function PagerObj(op) {
            var obj = new Object;
            obj.Page = page;

            var settings = $.extend({
                wid: 0, //页面ID
                containerId: 'divPager',    //容器编号
                url: '', //分页请求URL地址
                extendParams: '', //URL地址扩展参数
                callbackFn: null,  //加载完毕后的回调函数
                callbackFn_par: ''
            }, op);

            function page(currentIndex) {
                if (CheckSession() == false) {
                    $.messager.alert('提示信息', '超时,请按F5刷新!', 'info', function () {
                        callbackF();
                    });
                } else {
                    var finalUrl = settings.url;
                    if (finalUrl.indexOf('?') == -1) {
                        finalUrl += '?';
                    }

                    finalUrl += '&p=' + currentIndex;
                    finalUrl += '&clearBuffer=' + RandomKey(); //消除浏览器缓存            
                    finalUrl += '&wid=' + parseInt(settings.wid);
                    finalUrl += '&loadmark=' + parseInt(settings.loadmark);
                    //alert(settings.extendParams);
                    $.ajax({
                        type: "POST",
                        async: false,
                        url: finalUrl,
                        data: settings.extendParams,
                        success: function (html) {
                            
                        }
                    });
                }
            }

            return obj;
        }
        function go(f) {
            if (f) {
                f();
            }
        }
        function add(i) {
            alert(1 + i);
        }
        window.onload = function () {
            go(function () {
                add(123);
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
