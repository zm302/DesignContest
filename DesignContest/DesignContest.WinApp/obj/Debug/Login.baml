   M S B A M L   `   `   `  ����O  KDesignContest.WinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DesignContest.WinAppDesignContest.WinApp  5   	        DesignContest.WinApp.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:DesignContest.WinApp     5   	     � Title$  Login��5   	   $��560.0��6   $��1200.0��6&    � WindowStartupLocation$ CenterScreen=�65    � WindowStyle$
 None=�6Z    � WindowState$ 	Maximized=�6m    � Icon$ Resources/SLMS.png��6�   ��5	      �� 5
   
    �� ImageSource$ Resources/bg_homepage.png��6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��781* �6   �� 5      $
��411* �6    � RowDefinitions 5   
   �� 5      $	��98* �6   �� 5      $
��782* �6   �� 5      $��20 �6   .+�5   
   � $��2��6    5      �� 5      $��27 �6    �� 5      $	��71* �6    .+�5      �� -   5         ��Name$ btnMini��5      $��Right=�6&   $��0,0,35,0q�6B   $��Center=�6T      MiniButtonTemplate#��[  6o   6�   �� 5      -   5        $ btnClose��5      $��Right=�6'   $��0,0,5,0q�6C   $��Center=�6T     ClosedButtonTemplate#��[ 6o   6�   5      �� 5   
   $��Right=�6   $��0,262,165,0q�61   $	��Top=�6F   $��1��6^   $��2��6k   .+�5      �� $��Center=�6   $��Center=�66   �� 5       $��Center=�6   $��Center=�66   $��0,40,0,0q�6Q   	 �� Orientation$	 
Horizontal=�6c   .+�5!      ��   lblText#��[ 6   $��用户名：��69   �� 5"      -   5        $��txtUserName��5"        txtText#��[ 6-   
 �� TextWrapping$

 Wrap=�6N    �� CharacterCasing$ Normal=�6b   $�� ��6{   5#      �� 5$      $��Center=�6   $��Center=�66   $��0,10,0,0q�6Q   $	 
Horizontal=�6c   .+�5%      �� $��	密码：��6   #��[ 6&   G� 5&      -   5        $��	txtUserPW��5&        txtPassWord#��[ 6/   5(      �� 5)      $��Center=�6   $��Center=�66   $��0,10,0,0q�6Q   $	 
Horizontal=�6c   .+�5*      �� -   5        $��btnOk��5*   >     	btnSubmit#��[ 6    �� 	IsDefault . 6`   �� 5+      -   5        $��	btnCancel��5+   >     	btnCancel#��[ 6   $��30,0,0,0q�6O    . 6z   5,      5-      5.      5/      