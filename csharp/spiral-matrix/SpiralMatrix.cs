public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int top = 0, bottom = size - 1, left = 0, right = size - 1 ;

        var output = new int[size, size];

        int counter = 0;

        while (true)
        {
            if (left > right)
                break;

            // fill top row
            for (int i = left; i <= right; i++)
                output[top, i] = ++counter;
            top++;

            if (top > bottom)
                break;

            // fill right column
            for (int i = top; i <= bottom; i++)
                output[i, right] = ++counter;
            right--;

            if (left > right)
                break;

            // fill bottom row
            for (int i = right; i >= left; i--)
                output[bottom, i] = ++counter;
            bottom--;

            if (top > bottom)
                break;

            // fill left column
            for (int i = bottom; i >= top; i--)
                output[i, left] = ++counter;
            left++;
        }

        return output;
    }
}
