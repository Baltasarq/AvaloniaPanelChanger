namespace PanelChanger.Ui;


using System.Collections.Generic;
using Avalonia.Controls;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        var CbPanel = this.GetControl<ComboBox>( "CbPanel" );
        var MainPanel = this.GetControl<DockPanel>( "MainPanel" );
        
        CbPanel.SelectionChanged += (_, _) => this.ChangeTo( CbPanel.SelectedIndex );
        MainPanel.Loaded += (_, _) => this.ChangeTo( 0 );
    }

    private void ChangeTo(int index)
    {
        var MainPanel = this.GetControl<DockPanel>( "MainPanel" );
        var panels = new List<DockPanel> {
            this.GetControl<DockPanel>( "Panel1" ),
            this.GetControl<DockPanel>( "Panel2" ),
            this.GetControl<DockPanel>( "Panel3" ) };
        
        // Hide them all
        panels.ForEach(panel => panel.IsVisible = false );
        
        // Bring the one we want
        var panel = panels[ index ];
        panel.IsVisible = true;
        panel.Width = MainPanel.Bounds.Width;
        panel.Height = MainPanel.Bounds.Height;
    }
}
