   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      C ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ToDoList.GaugesToDoList.Gauges 5         ToDoList.Gauges.Gauge360   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      0gaugesclr-namespace:ToDoList.Gauges     5      .��5
      �   � RowDefinitions  5   
   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
      LiveCharts.Wpf.Gauge  $��0��6   $��0��6!   $��5q�61      Uses360Mode .    From$ 0Q�5      	   To$	 100Q�6      Value$ 50Q�6&     5   
   $��0��6   $��1��6!   $��5q�61    . $ 0Q�5      $	 100Q�6   $ 50Q�6&      GaugeRenderTransform 5      V� 5      .~�5       ��  �� Angle$ 90Q�6&   63   �� 5!       �� ScaleX$ -1Q�6%   63   5"      5$        5&   
   $��1��6   $��0��6!   $��5q�61    . $ 0Q�5(      $	 100Q�6   $ 20Q�6&   	   HighFontSize$	 60X�5)      
�������
   InnerRadius$
 0X�5*         GaugeBackground �	#BE54A3E96$     5.   
   $��1��6   $��1��6!   $��5q�61    . $ 0Q�50      $	 100Q�6   $ 50Q�6&   $	 60X�51      ���#424242   	FromColor$ White��52         ToColor$ Black��6&   $
 0X�53      
 ���� 54        57   
   $��2��6   $��0��6!   $��5q�61   $ 0Q�58      $	 100Q�6   $ 50Q�6&     5;   
   $��2��6   $ 0Q�5<      $	 100Q�6   $ 50Q�6&    . $��40(�5>      
�������$ White��5?      $ White��6&   
 ����    LabelsVisibility$ 	Collapsed=�5A      $��2��61   $��150,0,-39,-31q�6E    J� RenderTransformOrigin$ 0.5,0.5&�6\   z�5B      V� 5C      .~�5D      �� �� 5E      �� 5F      $ -0.284Q�6&   T� 5G      5H         GaugeActiveFill 5J      �� 5K      .��5L      �  � Color$ Yellow��6#    � Offset$	 0.0Q�62   � 5M      $ Orange��6#   $	 0.5Q�62   � 5N      $	 Red��6#   $	 1.0Q�6/   5O      5Q      5S      5T      