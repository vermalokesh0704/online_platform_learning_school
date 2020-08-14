<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageonline_user.master" AutoEventWireup="true" CodeFile="notes_subject_wise.aspx.cs" Inherits="online_user_notes_subject_wise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="page-title  parallax" data-jarallax='{"speed": 0.0}' style="background-image: url(../images/pattern/pattern-bg.png);">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <div class="page-title-name">
                    <h1 style="color:#20B2AA;">Subject Wise Notes/Video's<asp:Label runat="server" ID="class_name"></asp:Label></h1>
                </div>
              <%--  <p style="color:black;">
                    Cell meaning the cellular level of the body and Salt meaning mineral salts. There are 12 basic minerals are or tissue salt or cell salt in our bodies. They include a form of calcium, potassium, magnesium, iron, sodium, and silica which work at the cellular level. Our body needs balanced mineral level to function properly. Each cell salt has specific healing properties for physical and mental health. These salts can be easily absorbed by melting it in the mouth and do not need to be broken down in the stomach.

Cell Salts are safe and nontoxic hence can be taken by all age groups without any side effects. This is also a cost-effective form of treatment which does not require hospitalization and surgeries.
                </p>--%>

            </div>
        </div>
    </div>
</section>

    <!--=================================
page-title -->

    <section class="page-section-ptb">

        <div class="container" runat="server" id="class_9_10" visible="false">
           <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix" >
                        <img class="img-responsive" src="../images/subjects/science.jpg" alt="" style="height:278px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Science</a>
                        </div>

                        <div class="entry-content">
                            <p>
                                Science is a universal subject that spans the branch of knowledge that examines the structure and behavior of the physical and natural world through observation and experiment. Science education is most commonly broken down into the following three fields: Biology, Chemistry, and Physics.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Sci">Notes </a>
                            </div>
                              <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Sci">Videos</a>
                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix" >
                        <img class="img-responsive" src="../images/subjects/MATHEMATICS800x352.png" alt="" style="height:280px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Mathematics</a>
                        </div>

                        <div class="entry-content">
                            <p>
                               Topics in mathematics that every educated person needs to know to process, evaluate, and understand the numerical and graphical information in our society. Applications of mathematics in problem solving, finance, probability, statistics, geometry, population growth.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Mat">Notes</a>
                            </div>
                            <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Mat">Videos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/english.jpg" alt="" style="height:284px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>English 
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                          English language classes are offered through undergraduate and graduate programs that include English, English education, English literature and English for foreign language students. The types of courses taken in English-related degree programs depend on the program's area of study, but they often focus on literature, writing, grammar or pronunciation.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Eng">Notes</a>

                            </div>
                             <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Eng">Videos</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/hindi.jpg" alt="" style="height:266px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Hindi 
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                       Hindi is the national language of India; but, it is one of several languages spoken in different parts of the sub-continent.  ‘National’ should be understood as meaning the ‘official’ or ‘link’ language.  The homeland of Hindi is in the North of India, but it is studied, taught, spoken and understood widely throughout the sub-continent, whether as mother tongue or as a second or a third language.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Hin">Notes</a>

                            </div>
                            <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Hin">Videos</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" runat="server" id="pcm_pcb_11_12" visible="false">
        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/english.jpg" alt="" style="height:285px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>English 
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                          English language classes are offered through undergraduate and graduate programs that include English, English education, English literature and English for foreign language students. The types of courses taken in English-related degree programs depend on the program's area of study, but they often focus on literature, writing, grammar or pronunciation.
                            </p>
                        </div>
                        <div class="entry-share clearfix" >
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Eng">Notes</a>
                            </div>
                             <div class="entry-button ">
                                  <a type="button" class="button small" href="videos.aspx?sub=Eng">Videos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/hindi.jpg" alt="" style="height:266px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Hindi 
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                       Hindi is the national language of India; but, it is one of several languages spoken in different parts of the sub-continent.  ‘National’ should be understood as meaning the ‘official’ or ‘link’ language.  The homeland of Hindi is in the North of India, but it is studied, taught, spoken and understood widely throughout the sub-continent, whether as mother tongue or as a second or a third language.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Hin">Notes</a>

                            </div>
                             <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Hin">Videos</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
           <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix" >
                        <img class="img-responsive" src="../images/subjects/Physics.jpg" alt="" style="height:278px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Physics</a>
                        </div>

                        <div class="entry-content">
                            <p>
                                The main objective of these subjects is to study and try to understand the universe and everything in it. What is physics? Physics is the branch of science which deals with matter and its relation to energy. It involves study of physical and natural phenomena around us.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Phy">Notes</a>
                            </div>
                             <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Phy">Videos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/chemistry_2018_640.jpg" alt="" style="height:300px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Chemistry
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                               Chemistry is the study of matter, its properties, how and why substances combine or separate to form other substances, and how substances interact with energy.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Che">Notes</a>

                            </div>
                              <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Che">Videos</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;" runat="server" id="math">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix" >
                        <img class="img-responsive" src="../images/subjects/MATHEMATICS800x352.png" alt="" style="height:300px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Mathematics</a>
                        </div>

                        <div class="entry-content">
                            <p>
                               Topics in mathematics that every educated person needs to know to process, evaluate, and understand the numerical and graphical information in our society. Applications of mathematics in problem solving, finance, probability, statistics, geometry, population growth
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Mat">Notes</a>
                            </div>
                             <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Mat">Videos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right:40px;" runat="server" id="bio">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix" >
                        <img class="img-responsive" src="../images/subjects/biology.jpg" alt="" style="height:317px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Biology</a>
                        </div>

                        <div class="entry-content">
                            <p>
                               Biology is the natural science that studies life and living organisms, including their physical structure, chemical processes, molecular interactions, physiological mechanisms, development and evolution.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Bio">Notes</a>
                            </div>
                              <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Bio">Videos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>

        
    </div>

        <div class="container" runat="server" id="commerce_11_12" visible="false">
           <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix" >
                        <img class="img-responsive" src="../images/subjects/accountancy.jpeg" alt="" style="height:278px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Accountancy </a>
                        </div>

                        <div class="entry-content">
                            <p>
                                This course focuses on the process of auditing financial statements. It also includes discussions of the accounting concepts, profession, its regulatory and legal liability environments, plus the need for the audit function, professional standards and conduct.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Acc">Notes</a>
                            </div>
                              <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Acc">Videos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/Business-St-Daksh.png" alt="" style="height:285px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Business Studies
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                               Business Studies is a broad subject in the Social Sciences, allowing the in-depth study of a range of specialties such as accountancy, finance, organisation, human resources management and marketing.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Bus">Notes</a>

                            </div>
                               <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Bus">Videos</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix" >
                        <img class="img-responsive" src="../images/subjects/Economics-ee66b8ad3f654cb2814dadc1eda2654d.jpg" alt="" style="height:268px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Economics</a>
                        </div>

                        <div class="entry-content">
                            <p>
                               Economics is a social science concerned with the production, distribution, and consumption of goods and services. ... Economics can generally be broken down into macroeconomics, which concentrates on the behavior of the aggregate economy, and microeconomics, which focuses on individual consumers and businesses.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Eco">Notes</a>
                            </div>
                            <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Eco">Videos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-right:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/english.jpg" alt="" style="height:266px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>English 
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                          English language classes are offered through undergraduate and graduate programs that include English, English education, English literature and English for foreign language students. The types of courses taken in English-related degree programs depend on the program's area of study, but they often focus on literature, writing, grammar or pronunciation.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Eng">Notes</a>

                            </div>
                             <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Eng">Videos</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-6" style="padding-left:40px;">
                <div class="blog-entry mb-50">
                    <div class="entry-image clearfix">
                        <img class="img-responsive" src="../images/subjects/hindi.jpg" alt="" style="height:266px;">
                    </div>
                    <div class="blog-detail">
                        <div class="entry-title mb-10">
                            <a>Hindi 
                            </a>
                        </div>

                        <div class="entry-content">
                            <p>
                       Hindi is the national language of India; but, it is one of several languages spoken in different parts of the sub-continent.  ‘National’ should be understood as meaning the ‘official’ or ‘link’ language.  The homeland of Hindi is in the North of India, but it is studied, taught, spoken and understood widely throughout the sub-continent, whether as mother tongue or as a second or a third language.
                            </p>
                        </div>
                        <div class="entry-share clearfix">
                            <div class="entry-button">
                                  <a type="button" class="button small" href="notes.aspx?sub=Hin">Notes</a>

                            </div>
                              <div class="entry-button">
                                  <a type="button" class="button small" href="videos.aspx?sub=Hin">Videos</a>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</section>
    <section id="raindrops" class="raindrops" style="height: 50px;"></section>
    <section class="action-box theme-bg full-width">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <h3><strong>Disclaimer  </strong></h3>
                    <p>The Hogwarts Institute Website is for educational and informational purposes only.  Information contained in this website can and will change without notice.  The institute shall not be liable for any special, incidental, or consequential damages resulting from the use of this website.  
 
Every effort is made to assure that the most accurate and current information is posted on this site.  The institute does not guarantee this website is free from typographical errors or inadvertently inaccurate information.  
 
The institute makes no representations or warranties regarding the condition or functionality of this website, its suitability for use, or that this web service will be uninterrupted or error-free. </p>

                </div>
            </div>
        </div>
    </section>

</asp:Content>

