<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("Default.aspx", "Default", "~/Default.aspx");
        routes.MapPageRoute("cell_salt", "cell_salt", "~/cell_salt.aspx");
        routes.MapPageRoute("BioCombinations", "BioCombinations", "~/BioCombinations.aspx");
        routes.MapPageRoute("cellsalts4pets", "cellsalts4pets", "~/cellsalts4pets.aspx");
        routes.MapPageRoute("cellsalts4sports", "cellsalts4sports", "~/cellsalts4sports.aspx");
        routes.MapPageRoute("Angelcardreading", "Angelcardreading", "~/Angelcardreading.aspx");
           routes.MapPageRoute("Tarotcardreading", "Tarotcardreading", "~/Tarotcardreading.aspx");

        routes.MapPageRoute("Dosage", "Dosage", "~/Dosage.aspx");
        routes.MapPageRoute("Potency", "Potency", "~/Potency.aspx");
        routes.MapPageRoute("Dos_Donts", "Dos_Donts", "~/Dos_Donts.aspx");
        routes.MapPageRoute("usefullvideos", "usefullvideos", "~/usefullvideos.aspx");
        routes.MapPageRoute("ailments", "ailments", "~/ailments.aspx");
        routes.MapPageRoute("aboutus", "aboutus", "~/aboutus.aspx");
        routes.MapPageRoute("meditation4health", "meditation4health", "~/meditation4health.aspx");
        routes.MapPageRoute("Angelcardreadingform", "Angelcardreadingform", "~/Angelcardreadingform.aspx");


        routes.MapPageRoute("FAQ", "FAQ", "~/FAQ.aspx");
        routes.MapPageRoute("terms_and_conditions", "terms_and_conditions", "~/terms_and_conditions.aspx");
        routes.MapPageRoute("contact_us", "contact_us", "~/contact_us.aspx");
        routes.MapPageRoute("Why_CellSalts4health", "Why_CellSalts4health", "~/Why_CellSalts4health.aspx");
        routes.MapPageRoute("Benefits_to_Doctors", "Benefits_to_Doctors", "~/Benefits_to_Doctors.aspx");


        routes.MapPageRoute("signup", "Reports/signup", "~/Reports/signup.aspx");
        routes.MapPageRoute("login", "Reports/login", "~/Reports/login.aspx");
        routes.MapPageRoute("Forget_Login_Password", "Reports/Forget_Login_Password", "~/Reports/Forget_Login_Password.aspx");


        routes.MapPageRoute("User_Dashboard", "online_user/User_Dashboard", "~/online_user/User_Dashboard.aspx");
        routes.MapPageRoute("online_usercell_salt", "online_user/cell_salt", "~/online_user/cell_salt.aspx");
        routes.MapPageRoute("online_userBioCombinations", "online_user/BioCombinations", "~/online_user/BioCombinations.aspx");
        routes.MapPageRoute("online_usercellsalts4pets", "online_user/cellsalts4pets", "~/online_user/cellsalts4pets.aspx");
        routes.MapPageRoute("online_usercellsalts4sports", "online_user/cellsalts4sports", "~/online_user/cellsalts4sports.aspx");
        routes.MapPageRoute("online_userdoctor_profile", "online_user/doctor_profile", "~/online_user/doctor_profile.aspx");
        routes.MapPageRoute("online_userAngelcardreading", "online_user/Angelcardreading", "~/online_user/Angelcardreading.aspx");
        routes.MapPageRoute("online_userTarotcardreading", "online_user/Tarotcardreading", "~/online_user/Tarotcardreading.aspx");
        routes.MapPageRoute("online_userDosage", "online_user/Dosage", "~/online_user/Dosage.aspx");
        routes.MapPageRoute("online_userPotency", "online_user/Potency", "~/online_user/Potency.aspx");
        routes.MapPageRoute("online_userDos_Donts", "online_user/Dos_Donts", "~/online_user/Dos_Donts.aspx");
        routes.MapPageRoute("online_userusefullvideos", "online_user/usefullvideos", "~/online_user/usefullvideos.aspx");
        routes.MapPageRoute("online_userailments", "online_user/ailments", "~/online_user/ailments.aspx");
        routes.MapPageRoute("online_usermeditation4health", "online_user/meditation4health", "~/online_user/meditation4health.aspx");
        routes.MapPageRoute("online_usermeditation4healthform", "online_user/meditation4healthform", "~/online_user/meditation4healthform.aspx");
        routes.MapPageRoute("online_userAngelcardreadingform", "online_user/Angelcardreadingform", "~/online_user/Angelcardreadingform.aspx");
        routes.MapPageRoute("online_userTarotcardreadingform", "online_user/Tarotcardreadingform", "~/online_user/Tarotcardreadingform.aspx");
        routes.MapPageRoute("online_userFAQ", "online_user/FAQ", "~/online_user/FAQ.aspx");
        routes.MapPageRoute("online_userterms_and_conditions", "online_user/terms_and_conditions", "~/online_user/terms_and_conditions.aspx");
        routes.MapPageRoute("online_usercontact_us", "online_user/contact_us", "~/online_user/contact_us.aspx");
        routes.MapPageRoute("online_userWhy_CellSalts4health", "online_user/Why_CellSalts4health", "~/online_user/Why_CellSalts4health.aspx");
        routes.MapPageRoute("online_userBenefits_to_Doctors", "online_user/Benefits_to_Doctors", "~/online_user/Benefits_to_Doctors.aspx");

        routes.MapPageRoute("online_userorder_medicine", "online_user/order_medicine", "~/online_user/order_medicine.aspx");


        routes.MapPageRoute("online_userwhy_meditation", "online_user/why_meditation", "~/online_user/why_meditation.aspx");
        routes.MapPageRoute("online_userhow_it_is_made", "online_user/how_it_is_made", "~/online_user/how_it_is_made.aspx");


        routes.MapPageRoute("online_userknow_my_cell_salts", "online_user/know_my_cell_salts", "~/online_user/know_my_cell_salts.aspx");
        routes.MapPageRoute("online_userknow_my_cell_salts_deficiencies", "online_user/know_my_cell_salts_deficiencies", "~/online_user/know_my_cell_salts_deficiencies.aspx");
        routes.MapPageRoute("online_userbirthchart", "online_user/birthchart", "~/online_user/birthchart.aspx");
        routes.MapPageRoute("online_userFACIAL_ANALYSIS", "online_user/FACIAL_ANALYSIS", "~/online_user/FACIAL_ANALYSIS.aspx");


        routes.MapPageRoute("online_userConsult_online_new", "online_user/Consult_online_new", "~/online_user/Consult_online_new.aspx");
        routes.MapPageRoute("online_userprofile_update", "online_user/profile_update", "~/online_user/profile_update.aspx");
        routes.MapPageRoute("online_userknow_my_cell_salt_quries", "online_user/know_my_cell_salt_quries", "~/online_user/know_my_cell_salt_quries.aspx");
        routes.MapPageRoute("online_useradd_family", "online_user/add_family", "~/online_user/add_family.aspx");
        routes.MapPageRoute("online_useruser_Consultation", "online_user/user_Consultation", "~/online_user/user_Consultation.aspx");


        routes.MapPageRoute("online_usermy_orders", "online_user/my_orders", "~/online_user/my_orders.aspx");
        routes.MapPageRoute("online_userrefer_friend", "online_user/refer_friend", "~/online_user/refer_friend.aspx");
        routes.MapPageRoute("online_userwebsite_review", "online_user/website_review", "~/online_user/website_review.aspx");
        routes.MapPageRoute("Logout", "Logout", "~/Logout.aspx");
        routes.MapPageRoute("online_userWhy_Consult_Online", "online_user/Why_Consult_Online", "~/online_user/Why_Consult_Online.aspx");
        routes.MapPageRoute("online_useraboutus", "online_user/aboutus", "~/online_user/aboutus.aspx");


        routes.MapPageRoute("Doctor_dashboard", "Doctor/Doctor_dashboard", "~/Doctor/Doctor_dashboard.aspx");
        routes.MapPageRoute("Doctorcell_salt", "Doctor/cell_salt", "~/Doctor/cell_salt.aspx");
        routes.MapPageRoute("DoctorBioCombinations", "Doctor/BioCombinations", "~/Doctor/BioCombinations.aspx");
        routes.MapPageRoute("Doctorcellsalts4pets", "Doctor/cellsalts4pets", "~/Doctor/cellsalts4pets.aspx");
        routes.MapPageRoute("Doctorcellsalts4sports", "Doctor/cellsalts4sports", "~/Doctor/cellsalts4sports.aspx");
        routes.MapPageRoute("DoctorAngelcardreading", "Doctor/Angelcardreading", "~/Doctor/Angelcardreading.aspx");
        routes.MapPageRoute("DoctorDosage", "Doctor/Dosage", "~/Doctor/Dosage.aspx");
        routes.MapPageRoute("DoctorPotency", "Doctor/Potency", "~/Doctor/Potency.aspx");
        routes.MapPageRoute("DoctorDos_Donts", "Doctor/Dos_Donts", "~/Doctor/Dos_Donts.aspx");
        routes.MapPageRoute("Doctorusefullvideos", "Doctor/usefullvideos", "~/Doctor/usefullvideos.aspx");
        routes.MapPageRoute("Doctorailments", "Doctor/ailments", "~/Doctor/ailments.aspx");


        routes.MapPageRoute("DoctorFAQ", "Doctor/FAQ", "~/Doctor/FAQ.aspx");
        routes.MapPageRoute("Doctorterms_and_conditions", "Doctor/terms_and_conditions", "~/Doctor/terms_and_conditions.aspx");
        routes.MapPageRoute("Doctorcontact_us", "Doctor/contact_us", "~/Doctor/contact_us.aspx");
        routes.MapPageRoute("DoctorWhy_CellSalts4health", "Doctor/Why_CellSalts4health", "~/Doctor/Why_CellSalts4health.aspx");
        routes.MapPageRoute("DoctorBenefits_to_Doctors", "Doctor/Benefits_to_Doctors", "~/Doctor/Benefits_to_Doctors.aspx");



        routes.MapPageRoute("Doctorknow_my_cell_salts", "Doctor/know_my_cell_salts", "~/Doctor/know_my_cell_salts.aspx");
        routes.MapPageRoute("Doctorrknow_my_cell_salts_deficiencies", "Doctor/know_my_cell_salts_deficiencies", "~/Doctor/know_my_cell_salts_deficiencies.aspx");
        routes.MapPageRoute("Doctorrbirthchart", "Doctor/birthchart", "~/Doctor/birthchart.aspx");
        routes.MapPageRoute("DoctorrFACIAL_ANALYSIS", "Doctor/FACIAL_ANALYSIS", "~/Doctor/FACIAL_ANALYSIS.aspx");


        routes.MapPageRoute("DoctorrConsult_online_new", "Doctor/Consult_online_new", "~/Doctor/Consult_online_new.aspx");
        routes.MapPageRoute("Doctorrprofile_update", "Doctor/profile_update", "~/Doctor/profile_update.aspx");
        routes.MapPageRoute("Doctorrknow_my_cell_salt_quries", "Doctor/know_my_cell_salt_quries", "~/Doctor/know_my_cell_salt_quries.aspx");
        routes.MapPageRoute("Doctorradd_family", "Doctor/add_family", "~/Doctor/add_family.aspx");
        routes.MapPageRoute("DoctorrConsult_online_with_user", "Doctor/Consult_online_with_user", "~/Doctor/Consult_online_with_user.aspx");


        routes.MapPageRoute("Doctorrmy_orders", "Doctor/my_orders", "~/Doctor/my_orders.aspx");
        routes.MapPageRoute("Doctorrrefer_friend", "Doctor/refer_friend", "~/Doctor/refer_friend.aspx");
        routes.MapPageRoute("Doctorrwebsite_review", "Doctor/website_review", "~/Doctor/website_review.aspx");

        routes.MapPageRoute("Doctorrwrite_testimonials", "Doctor/write_testimonials", "~/Doctor/write_testimonials.aspx");

        routes.MapPageRoute("Doctorrprofile_update_part2", "Doctor/profile_update_part2", "~/Doctor/profile_update_part2.aspx");
        routes.MapPageRoute("Doctorrprofile_update_part3", "Doctor/profile_update_part3", "~/Doctor/profile_update_part3.aspx");
        routes.MapPageRoute("Doctoraboutus", "Doctor/aboutus", "~/Doctor/aboutus.aspx");

        routes.MapPageRoute("AdminAdmin_Dashboard", "Admin/Admin_Dashboard", "~/Admin/Admin_Dashboard.aspx");
        routes.MapPageRoute("Adminpending_review", "Admin/pending_review", "~/Admin/pending_review.aspx");
        routes.MapPageRoute("Adminpending_testimonial", "Admin/pending_testimonial", "~/Admin/pending_testimonial.aspx");
        routes.MapPageRoute("Adminpending_login", "Admin/pending_login", "~/Admin/pending_login.aspx");

        routes.MapPageRoute("Admintransction", "Admin/transction_report", "~/Admin/transction_report.aspx");

        routes.MapPageRoute("Adminmedicine_order", "Admin/medicine_order", "~/Admin/medicine_order.aspx");


    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
