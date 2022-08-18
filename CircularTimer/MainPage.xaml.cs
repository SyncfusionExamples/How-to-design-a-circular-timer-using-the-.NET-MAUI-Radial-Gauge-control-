namespace CircularTimer;

public partial class MainPage : ContentPage
{
    bool isCircularTimerOn = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private void play_pause_Clicked(object sender, EventArgs e)
    {
        isCircularTimerOn = !isCircularTimerOn;
        if (isCircularTimerOn)
        {
            play.IsVisible = false;
            pause.IsVisible = true;
        }

        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (!isCircularTimerOn)
            {
                play.IsVisible = true;
                pause.IsVisible = false;
                return false;
            }

            Dispatcher.DispatchAsync(() =>
            {
                pointer.Value -= 1;
                if (pointer.Value == -1)
                {
                    isCircularTimerOn = false;
                    pointer.Value = 60;
                    timer.Text = "01:00";
                }
                else
                {
                    timer.Text = pointer.Value.ToString("00:00");
                }
            });

            return true;
        });
    }
}