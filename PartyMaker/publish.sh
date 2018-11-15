cd ../
git pull origin master
cd PartyMaker
rm -rf linux-publish/
dotnet publish --configuration Release -r ubuntu.16.04-x64 -o linux-publish
rm -rf linux-publish/appsett*
killall screen
cp -r linux-publish/* /var/www/partymaker
chmod +x /var/www/partymaker/PartyMaker
cd /var/www/partymaker/
screen -d -m ./PartyMaker
clear
echo " *******                     **            ****     ****           **                   
/**////**                   /**    **   **/**/**   **/**          /**                   
/**   /**  ******   ****** ****** //** ** /**//** ** /**  ******  /**  **  *****  ******
/*******  //////** //**//*///**/   //***  /** //***  /** //////** /** **  **///**//**//*
/**////    *******  /** /   /**     /**   /**  //*   /**  ******* /****  /******* /** / 
/**       **////**  /**     /**     **    /**   /    /** **////** /**/** /**////  /**   
/**      //********/***     //**   **     /**        /**//********/**//**//******/***   
//        //////// ///       //   //      //         //  //////// //  //  ////// ///    "
echo ""
echo Finalizado
