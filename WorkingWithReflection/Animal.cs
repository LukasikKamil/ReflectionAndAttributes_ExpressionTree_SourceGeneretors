namespace ALLinONE.Shared;

public class Animal
{
    [Coder("Kamil Łukasik", "08 August 2023")]
    [Coder("John Smith", "13 September 2023")]
    [Obsolete($"use {nameof(SpeakBetter)} instead.")]
    public void Speak()
    {
        WriteLine("Woof...");
    }

    public void SpeakBetter()
    {
        WriteLine("Woooooooof...");
    }
}
