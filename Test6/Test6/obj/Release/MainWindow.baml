   M S B A M L   `   `   `  ���� @  <Test6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Test6Test6      Test6.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $selfclr-namespace:Test6     SCustom@http://schemas.microsoft.com/winfx/2006/xaml/presentation/ribbon       � Title$  	MyNotepad��$	��450��$	��450�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$
 Open��  -   $	 New��  -   $
 Save��  -   $ SaveAs�� J� InputBindings �� 
 �� Key$ O�� �� 	Modifiers$
 Ctrlf� �� Command$
 Open���� $ N��$
 Ctrlf�$	 New���� $ S��$
 Ctrlf�$
 Save��.��� $��0,0,0,0q� � RowDefinitions �� $
��Auto ��� $��* �.+�+  %System.Windows.Controls.Ribbon.Ribbon  -     Name$ ribbon��$
��Auto��	   ApplicationMenu	 :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  .@�>  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   
  Name$
 appNew��$	��New��3  -System.Windows.Controls.Ribbon.RibbonMenuItem   ImageSource$ Resources/NEW.png��   KeyTip$ N�� m� InputGestureText$ Ctrl+N�� m� Command$	 New��  -   $
 appOpen��$
��Open��$ Resources/OPEN.png��$ O��$ Ctrl+O��$
 Open��  -   $
 appSave��$
��Save��$ Resources/SAVE.png��$ S��$ Ctrl+S��$
 Save��  -	   $
 	appSaveAs��$��Save As��$ Resources/SAVE AS.png��$ SaveAs��  -
   $
 appExit��$
��Exit��$ Resources/EXIT.png��   QuickAccessToolBar =  7System.Windows.Controls.Ribbon.RibbonQuickAccessToolBar  .@�1  +System.Windows.Controls.Ribbon.RibbonButton  -     Name$ saveButton1��   SmallImageSource$ Resources/SAVE.png��   KeyTip$ S��   ToolTipDescription$ Save (Ctrl + S)��$
��Save��  -   $ undoButton1��$ Resources/UNDO.png��{�.  $ Undo Typing (Ctrl + Z)��  -   $ redoButton1��$ Resources/REDO.png��{�.  $ Redo (Ctrl + Y)��   HelpPaneContent   -   $ 
helpButton��$ Resources/HELP.png��.@�.  (System.Windows.Controls.Ribbon.RibbonTab  $��GENERAL��.@�0	  *System.Windows.Controls.Ribbon.RibbonGroup	  -    	 Name$ CilpboradGroup��$��	Clipboard�� 	  ToolTipTitle$ 	Clipboard�� 	  ToolTipDescription$4 .See all the item you've copied to the Cipboard��.@�  -   $ pasteButton��   LargeImageSource$ Resources/PASTE.png��   Label$ Paste��$ V��$4 .Add content on the Clipboard to your documents��   ToolTipTitle$ Paste (Ctrl + V)�� ^� ShowDuration$
 1000��  -   $ 	cutButton��$ Resources/CUT.png��$	 Cut��$ X��{�.  $ Cut (Ctrl+X)��$Z TRemove the selection and put it on the Clipboard so you can paste it somewhere else ��$��ApplicationCommands.Cut��  -   $ 
copyButton��$ Resources/COPY.png��$
 Copy��$ C��{�.  $ Copy (Ctrl+C)��$U OPut a copy of the selection on the Clipboard so you can paste it somewhere else��$
 1000��	  -   $ 
EditsGroup��$��Edits��.@�  -   $ undoButton2��$ Resources/UNDO.png��$
 Undo��{�.  $ Undo (Ctrl+Z)��  -   $ redoButton2��$ Resources/REDO.png��$
 Redo��{�.  $ Redo (Ctrl+Y)��  -   $ selectAllButton��$ Resources/SELECT ALL.png��$ 
Select All��{�.  $ Select All (Ctrl+A)��$ Select all text��	  -   $ 	FontGroup��$
��Font��.@�  -   $ 
boldButton��$ Resources/BOLD.png��$
 Bold��$ B��{�.  $ Bold (Ctrl+B)��$ Make your text bold��  -   $ italicButton��$ Resources/ITALIC.png��$ Italic��$ I��{�.  $ Italic (Ctrl+I)��$ Italicize your text��  -   $ underlineButton��$ Resources/UNDERLINE.png��$ 	Underline��$ U��{�.  $ Underline (Ctrl+U)��$ Underlines your text��  -   $ strikeButton��$" Resources/STRIKE_THROUGH.png��$ Strike Through��{�.  $ Strikethrough��$6 0Cross something out by drawing a line through it��  -   $ deleteButton��$ Resources/DELETE.png��$ Delete��{�.    -   $ textColorButton��$ Resources/TEXT COLOR.png��$ 
Text Color��{�.  $ 
Text Color��$# Change the color of your text��  $��ADVANCED��.@�	  .@�  -   $ speechObject��$ Resources/SOUND.png��$ SpeechSynthesizer��{�.  $ Heelo��	  .@�  -   $ dateTime��$ Resources/DATE.png��$ 	Date/Time��	  .@�3
  -System.Windows.Controls.Ribbon.RibbonCheckBox
  -     
 Name$ autoComplete�� 
  Label$ AutoCompleteBarracks�� d� 	IsChecked$ FalseY��� -!    ��Name$ richTextBox1��$��1��$��10,10,10,10q����	#FFABB3AB  � 	Resources  ! �� 
TargetType" �� Property# �� Value��%3   'J�       �� "! J�.��� " �@��Margin$# 0q�