   M S B A M L   `   `   `  ����^  ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   O KDesignContest.WinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:DesignContest.WinAppDesignContest.WinApp 5   	   )   #DesignContest.WinApp.LaboratoryCtrl   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   4local"clr-namespace:DesignContest.WinApp     5   	   -   5          � Title$  LaboratoryCtrl��5
   	   $	��900��6    $
��1200��6-    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$
 None=�6_    � WindowState$ 	Maximized=�6r    � Icon$ Resources/SLMS.png��6�   .��5      � .+�5   
   � $��10q�6   ��5      �� 5       �� ImageSource$ Resources/mainbg.jpg��6    � RowDefinitions 5      �� 5      $��98 �6    �� 5      $
��auto �6    �� 5      $��80 �6    .+�5      � $��3��6   ��5      �� 5      $' !Resources/laboratoryctrltitle.png��6!    5      �� 5      $	��27* �6$   �� 5      $	��71* �6$   .+�5      �� -   5        $��imgBack��5      $��Resources/back.png��6'   $��32��6C   $��Right=�6N   $
��20,0q�6j   6x   5      � 5      $��1��6   $��20q�6    ��5       �� 5!      $! Resources/bg_frame_gray.png��6!    5#      �� 5$      �� 5%       � ColumnDefinitions 5'      �� 5(      $
��640* �6'   �� 5)      $
��560* �6'   .+�5+      �� $��实验室总监控区��6   $��20(�6-   $��0��6;   .��5,      � $��Center=�6    5-      �� 5.      $	��200 �6/   �� 5/      $	��200 �6/   �� 50      $	��200 �6/    52      �� 53      $	��140 �6,   �� 54      $	��140 �6,   �� 55      $	��140 �6,   .+�57      �� $��0��6!   $��0��6.   $��20q�6>   
�������$��1q�6^   ._�58      7   1System.Windows.Forms.Integration.WindowsFormsHost     Child. 59   "   %  System.Windows.Forms.PictureBox  -   5        	IpCamera1��"  System.Windows.Forms.Control	   Dock$
	 Fill=�59   C   
   	BackColorU QSystem.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a#  System.Drawing.ColorConverter$
 Black 6O   5:      5;      �� 5<      $��0��6!   $��1��6.   $��20q�6>   
�������$��1q�6^   ._�5=        . 5>   "     -   5        	IpCamera2��$
	 Fill=�5>   C   $
 Black 6O   5?      5@      �� 5A      $��0��6!   $��2��6.   $��20q�6>   
�������$��1q�6^   ._�5B        . 5C   "     -   5        	IpCamera3��$
	 Fill=�5C   C   $
 Black 6O   5D      5E      �� 5F      $��1��6!   $��0��6.   $��20q�6>   
�������$��1q�6^   ._�5G        . 5H   "     -   5        	IpCamera4��$
	 Fill=�5H   C   $
 Black 6O   5I      5J      �� 5K      $��1��6!   $��1��6.   $��20q�6>   
�������$��1q�6^   ._�5L        . 5M   "     -   5        	IpCamera5��$
	 Fill=�5M   C   $
 Black 6O   5N      5O      �� 5P      $��1��6!   $��2��6.   $��20q�6>   
�������$��1q�6^   ._�5Q        . 5R   "     -   5        	IpCamera6��$
	 Fill=�5R   C   $
 Black 6O   5S      5T      �� 5U      $��2��6!   $��0��6.   $��20q�6>   
�������$��1q�6^   ._�5V        . 5W   "     -	   5        	IpCamera7��$
	 Fill=�5W   C   $
 Black 6O   5X      5Y      �� 5Z      $��2��6!   $��1��6.   $��20q�6>   
�������$��1q�6^   ._�5[        . 5\   "     -
   5        	IpCamera8��$
	 Fill=�5\   C   $
 Black 6O   5]      5^      �� 5_      $��2��6!   $��2��6.   $��20q�6>   
�������$��1q�6^   ._�5`        . 5a   "     -   5        	IpCamera9��$
	 Fill=�5a   C   $
 Black 6O   5b      5c      5e      5f      �� 5g      $��实验室温湿差异��6   ���#51feea$��0��6C   $��1��6P   $��2��6`   $
��20,0q�6q   $��20(�6   .��5h      � $��20q�6    5i      �� 5j      $��4* �6,   �� 5k      $��* �6,   .+�5m      � -   5        $��	chartGrid��5m      5o      �� 5p      $��1��6!   
�������$��1q�6B   ._�5q      �� .+�5r   "   ��  实验室温湿信息分析：68   �� 5s   "   -   5        $��txtInfoAnalyze��5s   ,   $
��Wrap=�6B   6X   5t      5u      5v      5w      �� 5x      $!��实验室照明灯总开关��6   ���#51feea$��1��6D   $��0��6Q   $
��0,10q�6a   $��20(�6o   .��5y      �  5z      �� 5{      �� 5|       5~      �� 5      �� 5�      �� 5�      .+�5�      �� -   5        $��imgRoomLamp��5�       $��Resources/lamp_on.png��63   $��Right=�6R   $
��20,0q�6n   $��50��6|   �� 5�      -   5        $��imgRoomLamp1��5�       $��Resources/lamp_off.png��64   $
��Left=�6T   $
��20,0q�6o   $��50��6}   $��0��6�   $��1��6�   �� 5�      -   5        $��	imgSwitch��5�       $!��Resources/lampswitchOff.png��61   $	��100��6V   $��2��6b   $��2��6o   6   � 5�      $��1��6   .+�5�      �� 
���  ��$��Bottom=�6:   $��10q�6U   请谨慎使用！6i   5�      5�      5�      5�      � 5�      $��2��6   .+�5�      �� -   5        $��btnQuit��5�      $��Right=�6(   $	��Top=�6D   $	��100��6\   $��20(�6h   $
��20,0q�6v   .��6�   退出6�   5�      5�      5�      5�      