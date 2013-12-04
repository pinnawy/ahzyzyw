<%@ Page Title="药用植物学习" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="study.aspx.cs" Inherits="Ahzyzyw.Web.Study" %>
<asp:Content ID="Study" ContentPlaceHolderID="MainContent" runat="server">
<div>
    
<STYLE type=text/css>BODY {
	FONT-FAMILY: "宋体"; FONT-SIZE: 9pt
}
.p1 {
	FONT-FAMILY: "宋体"; FONT-SIZE: 9pt
}
.INPUT {
	PADDING-BOTTOM: 1px; BORDER-RIGHT-WIDTH: 1px; BACKGROUND-COLOR: #f0f1f7; PADDING-LEFT: 1px; PADDING-RIGHT: 1px; FONT-FAMILY: 宋体, Arial, Helvetica; BORDER-TOP-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; HEIGHT: 20px; FONT-SIZE: 9pt; BORDER-LEFT-WIDTH: 1px; CURSOR:pointer; PADDING-TOP: 1px
}
.iResult {
	PADDING-BOTTOM: 0px; BORDER-RIGHT-WIDTH: 0px; BACKGROUND-COLOR: #f0f1f7; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; FONT-FAMILY: 宋体, Arial, Helvetica; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: #ff0000; FONT-SIZE: 9pt; BORDER-LEFT-WIDTH: 0px; PADDING-TOP: 0px
}
</STYLE>

<SCRIPT>
    function ShowMeResult() {//Writed by QQ:170988779 At 2003-10-23 At ShangHai
        iform = document.testform;
        len = iform.elements.length;
        var n = ""
        for (i = 0; i < len; i++) {
            n = iform.elements[i].name;
            if (n.substring(0, 7) == "iResult" && (iform.elements[i].style.display == "none")) {
                iform.elements[i].style.display = "block";
                iform.iSee.value = "隐藏答案";
            }
            else if (iform.elements[i].style.display == "block") {
                iform.elements[i].style.display = "none";
                iform.iSee.value = "显示答案";
            }
        }
    }

    function submitit() {//Writed by QQ:170988779 At 2003-11-15;Edited at 2003-11-17
        iform = document.testform;
        len = iform.elements.length;
        var i = 0;
        var n = "";
        var m = "";
        for (i = 0; i < len; i++) {
            n = iform.elements[i].name;
            if (n.substring(0, 2) == "NO") {
                if (m != n) {
                    var aa = document.getElementsByName(n);
                    var nn = 0;
                    for (var ii = 0; ii < aa.length; ii++) {
                        if (aa[ii].checked) {
                            nn++;
                            break;
                        }
                    }
                    if (nn <= 0) {
                        alert("请做完所有考题方可提交！");
                        iform.elements[i].focus();
                        return false;
                    }
                }
                m = n;
            }
        }
        if (confirm("确认无误？")) {
            return true;
        }
        return false;
    }
</SCRIPT>

<TABLE border=0 cellSpacing=0 cellPadding=0 width=755 align=center>
<TBODY>
<TR>
<TD vAlign=bottom align=middle><IMG src="images/0501.gif" width="100%" height=10></TD></TR></TBODY></TABLE>
<TABLE style="BORDER-LEFT: #999999 1px solid; BORDER-RIGHT: #999999 1px solid" class=p1 border=0 cellSpacing=0 cellPadding=0 width=755 align=center>
<TBODY>
<TR>
<TD>
<DIV align=center>
<TABLE class=p1 border=0 width=400>
<TBODY>
<TR>
<TD align=middle><B><FONT color=#ff0000 size=3 face=黑体>药用植物学试卷1</FONT></B><BR>满分:100分&nbsp;您是第<FONT color=blue>1429</FONT>位自测者</TD></TR>
<TR>
<TD bgColor=#fff0f8><FONT color=#0080ff></FONT></TD></TR></TBODY></TABLE></DIV></TD></TR>
<TR>
<FORM onsubmit="return submitit();" method=post name=testform action=ShowMeResult.asp>
<TD><INPUT value=52 type=hidden name=TestID> <INPUT value="2011-11-18 10:56:30" type=hidden name=StartTime> <!--单选题开始!--><!--多选题开始!-->
<TABLE style="BORDER-COLLAPSE: collapse" id=AutoNumber3 class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#e8f3ff height=25 width="100%">&nbsp;&nbsp;<B>多项选择题(每题0分,共0题。少选视正确答案多少酹情给分，多选不得分)</B></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>1、单雌蕊的子房将来发育成的果实类型可能是</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value="（答案：A, C）" size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO519> A、荚果、核果<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO519> B、柑果<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO519> C、瘦果、蓇葖果<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO519> D、角果、双悬果<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>2、具基生胎座的雌蕊可能是</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value="（答案：A, B, C, D）" size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO518> A、单雌蕊 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO518> B、复雌蕊<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO518> C、离生心皮雌蕊<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO518> D、合生心皮雌蕊<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>3、外分泌组织包括 等</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value="（答案：A, B）" size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO517> A、腺毛<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO517> B、腺鳞<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO517> C、丁字毛 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO517> D、树脂道<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>4、木栓层是由 形成的。</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value=（答案：B） size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO516> A、形成层 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO516> B、木栓形成层<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO516> C、表皮<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO516> D、次生分生组织<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>5、原生本质部的导管多为 导管</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value="（答案：A, B）" size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO515> A、环纹<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO515> B、螺纹<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO515> C、梯纹或网纹 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO515> D、各种类型 <BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>6、观察淀粉粒一般采用 装片</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value=（答案：A） size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO514> A、水<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO514> B、水合氯醛<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO514> C、稀碘液<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO514> D、间苯三酚<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>7、子房壁与花托完全愈合的现象称</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value=（答案：C） size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO513> A、子房上位、下位花 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO513> B、子房半下位、周位花<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO513> C、子房下位、上位花 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO513> D、子房上位、周位花<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>8、四强雄蕊指该雄蕊群具：</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value=（答案：D） size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO512> A、四枚雄蕊<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO512> B、六枚雄蕊<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO512> C、雄蕊为二长四短<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO512> D、雄蕊为二短四长<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>9、某植物的体细胞、精细胞及胚乳细胞的染色体数分别为：</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value=（答案：D） size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO511> A、12、1 2、2 4 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO511> B、1 2、1 2、1 8<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO511> C、1 2、6、2 4 <BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO511> D、 12、6、1 8<BR></TD></TR></TBODY></TABLE>
<TABLE class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" colSpan=2>&nbsp;&nbsp;<B>10、茎的变态有 等类型。</B> </TD>
<TD noWrap><INPUT style="DISPLAY: none" class=iResult value="（答案：B, C）" size=30 name=iResult> </TD></TR>
<TR>
<TD height=20>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=A type=checkbox name=NO510> A、刺状茎、攀援茎、根状茎<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=B type=checkbox name=NO510> B、根状茎、鳞茎、茎卷须<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=C type=checkbox name=NO510> C、叶状茎、球茎、块茎<BR>&nbsp;&nbsp;&nbsp;&nbsp;<INPUT value=D type=checkbox name=NO510> D、肉质茎、刺状茎、叶状茎<BR></TD></TR></TBODY></TABLE>
<TABLE style="BORDER-COLLAPSE: collapse" id=AutoNumber2 class=p1 border=0 cellSpacing=0 borderColor=#111111 width="100%">
<TBODY>
<TR>
<TD bgColor=#f2f2f2 height=20 width="100%" align=middle><INPUT class=input value=" 提交 " type=submit>&nbsp;<INPUT class=input value=" 重置 " type=reset>&nbsp;<INPUT class=input onclick=Javascript:ShowMeResult(); value=查看答案 type=button name=iSee>&nbsp;<INPUT class=input onclick=location.reload() value=重新选题 type=button>&nbsp; <INPUT class=input onclick=history.go(-1); value=" 返回 " type=button><BR></TD></TR></TBODY></TABLE></TD><INPUT type=hidden name=ID1> <INPUT value=510;511;512;513;514;515;516;517;518;519; type=hidden name=ID2> <INPUT type=hidden name=ID3> </FORM></TR></TBODY></TABLE>
<TABLE border=0 cellSpacing=0 cellPadding=0 width=755 align=center>
<TBODY>
<TR>
<TD vAlign=top align=middle><IMG src="images/050.gif" width="100%" height=10></TD></TR></TBODY></TABLE>
</div>
</asp:Content>
