<html>
<body>
    <div>
        <%
            response.write("Hello World!")
        %>
        <script language="javascript" runat="server">
            Response.Write("Hello World!")
        </script>
    </div>
    <div>
        <%
            dim name
            name="Donald Duck"
            response.write("My name is: " & name)
            Dim fname(5),i
            fname(0) = "George"
            fname(1) = "John"
            fname(2) = "Thomas"
            fname(3) = "James"
            fname(4) = "Adrew"
            fname(5) = "Martin"

            For i = 0 to 5
                  response.write(fname(i) & "<br />")
            Next
        %>
    </div>
    <div>
<%
sub vbproc(num1,num2)
response.write(num1*num2)
end sub
%>
<p>您可以像这样调用一个程序：</p>
<p>结果：<%call vbproc(3,4)%></p>

<p>或者，像这样：</p>
<p>结果：<%vbproc 3,4%></p>    
<script language="javascript" runat="server">
    function jsproc(num1, num2) {
        Response.Write(num1 * num2)
    }
</script>
<p>结果：<%call jsproc(2,3) %></p>  
    </div>
    
<div>
<form action="#" method="get">
您的姓名：<input type="text" name="fname" size="20" />
<input type="submit" value="提交" />
</form>
<%
dim fname2
fname2=Request.QueryString("fname")
If fname2<>"" Then
      Response.Write("你好！" & fname2 & "！<br />")
      Response.Write("今天过得怎么样？")
End If
%>
    
<form action="#p" method="post">
您的姓名：<input type="text" name="fname3" size="20" />
<input type="submit" value="提交" />
</form>
<%
dim fname3
fname3=Request.Form("fname3")
If fname3<>"" Then
      Response.Write("您好！" & fname3 & "！<br />")
      Response.Write("今天过得怎么样？")
End If
%>    

</div>    

<div>
<%
Response.Cookies("firstname")="Alex"
fname4=Request.Cookies("firstname")
response.write("Firstname=" & fname4)

Response.Cookies("user")("firstname")="John"
Response.Cookies("user")("lastname")="Adams"
Response.Cookies("user")("country")="UK"
Response.Cookies("user")("age")="25"
dim x,y

 for each x in Request.Cookies
  response.write("<p>")
  if Request.Cookies(x).HasKeys then
    for each y in Request.Cookies(x)
      response.write(x & ":" & y & "=" & Request.Cookies(x)(y))
      response.write("<br />")
    next
  else
    Response.Write(x & "=" & Request.Cookies(x) & "<br />")
  end if
  response.write "</p>"
next
 %>
</div>
<div>

<%
Session("username")="Donald Duck"
Session("age")=50
%>
Welcome <%Response.Write(Session("username"))%>
</div>
<div>
There are 
<%
Response.Write(Application("users"))
%> 
active connections.
</div>
<div>
<p><!--#include file="b.asp"--></p>
</div>
<div>
<%
Set fs = Server.CreateObject("Scripting.FileSystemObject")
Set rs = fs.GetFile(Server.MapPath("b.asp"))
modified = rs.DateLastModified
%>
本文件的最后修改时间是：<%response.write(modified)
Set rs = Nothing
Set fs = Nothing
%>
</div>
<div>
<%
Set fs=Server.CreateObject("Scripting.FileSystemObject")

If (fs.FileExists("C:\inetpub\wwwroot2\b.asp"))=true Then 

Response.Write("文件 b.asp 存在。")

Else
      Response.Write("文件 b.asp 不存在。")
End If

set fs=nothing
%>
</div>
<div>
<%
Set fs=Server.CreateObject("Scripting.FileSystemObject")

Set f=fs.OpenTextFile(Server.MapPath("vbtest.txt"), 1)
Response.Write(f.ReadAll)
f.Close

Set f=Nothing
Set fs=Nothing
%>
</div>
<div>
<%
dim fs2, f2
set fs2=Server.CreateObject("Scripting.FileSystemObject")
set f2=fs2.GetFile(Server.MapPath("vbtest.txt"))
Response.Write("文件 vbtest.txt 的创建时间是：" & f2.DateCreated)
set f2=nothing
set fs2=nothing
%>
</div>
<div>
<%
 

Dim conn
Set conn = Server.CreateObject("ADODB.Connection")
conn.Open "driver={SQL Server};server=.; uid=sa;pwd=Hello123456!;database=test"

set rs = Server.CreateObject("ADODB.recordset")
rs.Open "Select * from mytesttable", conn

do until rs.EOF
    for each x in rs.Fields
       Response.Write(x.name)
       Response.Write(" = ")
       Response.Write(x.value & "<br />") 
    next
    Response.Write("<br />")
    rs.MoveNext
loop

rs.close
conn.close
%>
</div>
<div>
<%
Set MyBrow=Server.CreateObject("MSWC.BrowserType")
%>

<table border="1" width="65%">
   <tr>
     <td width="52%">客户机操作系统</td>
     <td width="48%"><%=MyBrow.platform%></td>
   </tr>
   <tr>
     <td >Web 浏览器</td>
     <td ><%=MyBrow.browser%></td>
   </tr>
   <tr>
     <td>浏览器版本</td>
     <td><%=MyBrow.version%></td>
   </tr>
   <tr>
     <td>框架支持</td>
     <td><%=MyBrow.frames%></td>
   </tr>
   <tr>
     <td>表格支持</td>
     <td><%=MyBrow.tables%></td>
   </tr>
   <tr>
     <td>音频支持</td>
     <td><%=MyBrow.backgroundsounds%></td>
   </tr>
   <tr>
     <td>Cookies 支持</td>
     <td><%=MyBrow.cookies%></td>
   </tr>
   <tr>
     <td>VBScript 支持</td>
     <td><%=MyBrow.vbscript%></td>
   </tr>
   <tr>
     <td>JavaScript 支持</td>
     <td><%=MyBrow.javascript%></td>
   </tr>
</table>
</div>
 
 <div>
 <p>下面的例子构建了一个内容列表：</p>

  
 
 </div>
</body>
</html>
