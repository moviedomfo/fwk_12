<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main_menu_2.ascx.cs" Inherits="Vivaldi.Menues.main_menu_2" %>
<link href="../Styles/Common.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">

    $(document).ready(function () {

        $('#img_search').click(function () {
            var s = $("#searchField").val();
            var path = Getrootpath('');

            document.location.href = path + '/Modules/Noticias/News.aspx?t=' + s;
            return false;
        });

        $("#searchField").keydown(function (event) {
            if (event.which == 13) {

                $("#searchField").fadeIn();
                $("#searchField").focus().select();
                var s = $("#searchField").val();
                var path = Getrootpath('');
                document.location.href = path + '/Modules/Noticias/News.aspx?t=' + s;
                return false;
            }
        });

    });

</script>
<div >
<ul id="menu"> 
  
   
    <li><a class="menuv_a"  href="/index.aspx">Home</a> 
    </li> 
    <li><a class="menuv_a" href="/svc.aspx">Servicios</a> 
        <ul id="servicios"> 
   
            <li>
                <img class="corner_inset_left img_menu" alt="" src="/img/corner_inset_left.png" />
                <a class="menuv_a" href="/architecture.aspx">Arquitectura de software</a>
                <img class="corner_inset_right img_menu" alt="" src="/img/corner_inset_right.png" />
            </li>
                
              <li><a class="menuv_a" href="satelliteapps.aspx" title="Aplicaciones satelites">Aplicaciones satelites</a></li>
              <li><a class="menuv_a" href="devtype.aspx" title="Tipos de desarrollos ">Tipos de desarrollos</a></li>
              <li><a class="menuv_a" href="softmaintenance.aspx" title="Mantenimiento de sistemas">Mantenimiento de sistemas</a></li>
              <li><a class="menuv_a" href="technologies.aspx" title="Tecnologías">Tecnologías</a></li>
             <li class ="last">
                <img class="corner_left img_menu" alt="" src="/img/corner_left.png" />
                <img class="middle img_menu" src="/img/dot.gif" alt=""/>
                <img class="corner_right img_menu" alt="" src="/img/corner_right.png" />
            </li>
        </ul> 
    </li>
    <li><a class="menuv_a" href="/about.aspx">Pelo-Soft</a>
        <ul id="cooperativa">
            <li>
                <img class="corner_inset_left img_menu" alt="" src="/img/corner_inset_left.png" />
                <a class="menuv_a" href="/About.aspx">Que es Pel-Soft ?</a>
                <img class="corner_inset_right img_menu" alt="" src="/img/corner_inset_right.png" />
            </li>
            <li><a class="menuv_a" href="/contact.aspx">Contactar</a></li>
            
            <li><a class="menuv_a" href="/experience.aspx">Experiencia</a></li>
             <li class ="last">
                <img class="corner_left img_menu" alt="" src="/img/corner_left.png" />
               <img class="middle img_menu" src="/img/dot.gif" alt="" />
                <img class="corner_right img_menu" alt="" src="/img/corner_right.png" />
            </li>
        </ul>
    </li>
  
   <%-- </li> 
    <li class="searchContainer"> 
        <div> 
        <input type="text" id="searchField" /> 
        <img id ="img_search" class = "img_src"  src="/img/magnifier.png" alt="Search" /></div> 
       <ul id="search"> 
            <li><input id="cbxAll" type="checkbox" />All</li> 
            <li><input id="Articles" type="checkbox" />Articles</li> 
            <li><input id="Tutorials" type="checkbox" />Tutorials</li> 
            <li><input id="Reviews" type="checkbox" />Reviews</li> 
            <li><input id="Resources" type="checkbox" />Resources</li> 
        </ul> 
    </li> --%>

     <%--<li><a class="menuv_a" href="/Modules/Admin/Admin_FactList.aspx">Abonados</a></li>--%>
       <li class="logo" >       
    </li> 

</ul> 

    <div style="float: right">
        <a href="http://ar.linkedin.com/in/marcelooviedo" style="font-size: 12px; text-decoration: none;">
            <span style="font: 80% Arial,sans-serif; color: #0783B6;">
                <img src="http://www.linkedin.com/img/webpromo/btn_in_20x15.png" width="20" height="15"
                    alt="Ver el perfil de Marcelo Oviedo en LinkedIn" style="vertical-align: middle"
                    border="0" />Marcelo Oviedo</span></a>
    </div>
</div>