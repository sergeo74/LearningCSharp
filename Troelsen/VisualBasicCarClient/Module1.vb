Imports CarLibrary

Module Module1

    Sub Main()
        Console.WriteLine("***** VB CarLibrary Client App *****")
        Dim myMiniVan As New MiniVan()
        myMiniVan.TurboBoost()
        Dim mySportCar As New SportCar()
        mySportCar.TurboBoost()
        Dim dreamCar As New PerformanceCar()
        dreamCar.PetName = "Hank"
        dreamCar.TurboBoost()
        Console.ReadKey()

    End Sub

End Module
