Program napisany w języku C# w środowisku Visual Studio. Pozwala na wczytanie dowolnego zdjęcia, modyfikację obrazu w oparciu o algorytm wyrównywania histogramu oraz w oparciu o filtry rozmywające (filtr uśredniający oraz filtr Gaussa).

Aby uruchomić program wystarczy otworzyć plik WindowsFormsApplication12.exe z folderu WindowsFormsApplication12/bin/Debug/

Plik: Edytor.Designer.cs tworzy interfejs GUI za pomocą Projektanta formularzy systemu Windows. Plik: Edytor.cs zawiera kod opisujący funkcje wywoływane dla poszczególnych komponentów składających się na GUI.

W chwili otwarcia programu ukazuje nam się okno interfejsu. Zawiera ono dwa PictureBox'y (pierwszy to obraz wejściowy a drugi wyjściowy). PictureBoxy automatycznie dopasowują swój rozmiar do paneli w których się znajdują po wczytaniu zdjęcia.(Dzięki właściwości SizeMode = AutoSize). Wczytujemy dowolny plik png. lub jpg.(klikając przycisk "Wczytaj" otwiera się openFileDialog). Następnie możemy modyfikować obraz klikając odpowiedni Button. Przycisk zapisz pozwala zapisać plik wynikowy o nazwie wpisanej w textBox (plik zapisze się w folderze: bin/Debug ). Wszystkie zaimplementowane w programie algorytmy bazują na Bitmapach zdjęć PictureBox'ów . Wczytują wartość koloru czerwonego/zielonego/niebieskiego każdego z pikseli zdjęcia/zdjęć wejściowych, zmieniając w odpowiedni dla danego algorytmu sposób ich wartość i przypisując ją dla pikseli obrazu wyjściowego. W momencie wykonywania algorytmu(po kliknięciu któregoś z przycisków) dokonuje się zmiana kursora na kursor czekania.

Cursor = Cursors.WaitCursor;

Filtry wyostrzające bazują na maskach 3x3 . Zaimplementowane jest w nich normalizowanie maski(czyli dzielimy się wynik przez sumę współczynników maski) - stosujemy ją aby uniknąć wyjścia z zakresu intensywności obrazu:

...

     int norm = 0;
        for (int i = 0; i < 3; i++)    
            for (int j = 0; j < 3; j++)
                norm += maska[i, j];
...

              if (norm != 0)
                {
                    R /= norm;
                    G /= norm;
                    B /= norm;
                }
                
  W Filtrze Laplace'a mamy do wyboru jedną z trzech masek(wybieramy zaznaczając odpowiedni RadioButton):
  
  if (radioButton1.Checked == true)
            {
                maska[0, 0] = 0;
                maska[0, 1] = -1;
                maska[0, 2] = 0;
                maska[1, 0] = -1;
                maska[1, 1] = 4;
                maska[1, 2] = -1;
                maska[2, 0] = 0;
                maska[2, 1] = -1;
                maska[2, 2] = 0;
            }
            else if(radioButton2.Checked == true)
            { 
                maska[0, 0] = -1;
                maska[0, 1] = -1;
                maska[0, 2] = -1;
                maska[1, 0] = -1;
                maska[1, 1] = 8;
                maska[1, 2] = -1;
                maska[2, 0] = -1;
                maska[2, 1] = -1;
                maska[2, 2] = -1;
            }
            else
            {
                maska[0, 0] = -2;
                maska[0, 1] = 1;
                maska[0, 2] = -2;
                maska[1, 0] = 1;
                maska[1, 1] = 4;
                maska[1, 2] = 1;
                maska[2, 0] = -2;
                maska[2, 1] = 1;
                maska[2, 2] = -2;
            }
                
 Filtry Statystyczne bazują natomiast na maskach 9x9      
 
            int[] tab_R = new int[9];
            int[] tab_G = new int[9];
            int[] tab_B = new int[9];
