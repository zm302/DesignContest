function backgroundreplace()
{
    var background=document.getElementById("header");
    background.style.backgroundImage="url(image/background2.jpg)";
    background.style.backgroundSize="500px 300px";
}
// function liaddpend()
// {
//     var li7=document.createElement("li");
//     var li5=document.getElementById('li5');
//     li5.appendChild(li7);
//     li7.innerHTML='<li id="li7">Html</li>';
//     li7.innerHTML='<li id="li7">CSS</li>';
//     li7.innerHTML='<li id="li7">Javascript</li>';
//     li7.innerHTML='<li id="li7">Ajax</li>';
// }
window.onload=function()
{
    backgroundreplace();
    liaddpend();
}