using System;

public class HandConfig
{

    public enum finger_conf_X_Thumb :   int { Straight, RightAngle, SlightlyRightAngle, Forward, SlightlyForward, YRotated  };
    public enum finger_conf_Y_Thumb :   int { Straight, BentIn, BentOut };
    public enum finger_conf_X :         int { Straight, OneBentIn, TwoBentIn, TwoSlitleyBentIn, AllSlitleyBentIn, AllBentIn };
    public enum finger_conf_Y :         int { Open, Closed, Entwined };

    public finger_conf_X_Thumb   conf_x_thumb;
    public finger_conf_Y_Thumb   conf_y_thumb;
    public finger_conf_X[]       conf_x;
    public finger_conf_Y[]       conf_y;


    public void configure(char[] ca)
    {
        finger_conf_X_Thumb temp_x_thumb = map_x_thumb(ca[0].ToString() + ca[1].ToString());
        finger_conf_Y_Thumb temp_y_thumb = map_y_thumb(ca[2].ToString() + ca[3].ToString());


        finger_conf_X[] temp_x = {
                                    map_x( ca[4].ToString()  + ca[5].ToString()  ),
                                    map_x( ca[8].ToString()  + ca[9].ToString()  ),
                                    map_x( ca[12].ToString() + ca[13].ToString() ),
                                    map_x( ca[16].ToString() + ca[17].ToString() )
                                 };
        finger_conf_Y[] temp_y = {
                                    map_y( ca[6].ToString()  + ca[7].ToString()  ),
                                    map_y( ca[10].ToString() + ca[11].ToString() ),
                                    map_y( ca[14].ToString() + ca[15].ToString() ),
                                    map_y( ca[18].ToString() + ca[19].ToString() )
                                 };

        conf_x_thumb = temp_x_thumb;
        conf_y_thumb = temp_y_thumb;
        conf_x       = temp_x;
        conf_y       = temp_y;
    }

    //   F0X0Y0F1X0Y0F2X0Y0F3X0Y0F4X0Y0
    finger_conf_X_Thumb map_x_thumb(string s)
    {
        switch (s)
        {
            case "X0": return finger_conf_X_Thumb.Straight;
            case "X1": return finger_conf_X_Thumb.RightAngle;
            case "X2": return finger_conf_X_Thumb.SlightlyRightAngle;
            case "X3": return finger_conf_X_Thumb.Forward; 
            case "X4": return finger_conf_X_Thumb.SlightlyForward;
            case "X5": return finger_conf_X_Thumb.YRotated;

            default: throw new Exception("Invalid Configuration");
        }
    }

    finger_conf_Y_Thumb map_y_thumb(string s)
    {
        switch (s)
        {
            case "Y0": return finger_conf_Y_Thumb.BentIn;
            case "Y1": return finger_conf_Y_Thumb.Straight;
            case "Y2": return finger_conf_Y_Thumb.BentOut;

            default: throw new Exception("Invalid Configuration");
        }
    }

    finger_conf_X map_x(string s)
    {
        switch (s)
        {
            case "X0": return finger_conf_X.Straight;
            case "X1": return finger_conf_X.OneBentIn;
            case "X2": return finger_conf_X.TwoBentIn;
            case "X3": return finger_conf_X.TwoSlitleyBentIn; 
            case "X4": return finger_conf_X.AllSlitleyBentIn;
            case "X5": return finger_conf_X.AllBentIn;

            default: throw new Exception("Invalid Configuration");
        }
    }

    finger_conf_Y map_y(string s)
    {
        switch (s)
        {
            case "Y0": return finger_conf_Y.Open;
            case "Y1": return finger_conf_Y.Closed;
            case "Y2": return finger_conf_Y.Entwined;

            default: throw new Exception("Invalid Configuration");
        }
    }
}
