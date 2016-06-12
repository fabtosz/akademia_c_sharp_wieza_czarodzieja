// Bartosz Fabiański
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication6
{

    public partial class Form1 : Form
    {
        Location currentLocation;

        RoomWithDoor magicRoom;
        Room library;
        RoomWithDoor tortureRoom;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside outland;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(magicRoom);
        }

        private void CreateObjects()
        {
            magicRoom = new RoomWithDoor("Sala magii", "starożytny gobelin i obsydianowe gargulce",
                    "kamienny portal w szkarłatnych płomieniach");
            library = new Room("Biblioteka", "wysokie przepastne regały pełne starożytnych manuskryptów");
            tortureRoom = new RoomWithDoor("Sala tortur", "ponury lock pełen szkieletów, klatek i brunatnych śladów krwi", "jedwabna kotara");

            frontYard = new OutsideWithDoor("Podwórze", false, "wielki kamienny portal w jaskrawo-zielonych płomieniach");
            backYard = new OutsideWithDoor("Ogród Posągów", true, "dębowe drzwi");
            outland = new Outside("Pustkowie", false);

            library.Exits = new Location[] { magicRoom, tortureRoom };
            magicRoom.Exits = new Location[] { library };
            tortureRoom.Exits = new Location[] { library };
            frontYard.Exits = new Location[] { backYard, outland };
            backYard.Exits = new Location[] { frontYard, outland };
            outland.Exits = new Location[] { backYard, frontYard };

            magicRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = magicRoom;

            tortureRoom.DoorLocation = backYard;
            backYard.DoorLocation = tortureRoom;
        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
                exits.Items.Add(currentLocation.Exits[i].Name);
            exits.SelectedIndex = 0;

            description.Text = currentLocation.Description;

            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }


    }
}
