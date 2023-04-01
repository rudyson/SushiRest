import style from "./AboutUsSlider.module.css";
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';
import firstSlider from "../../../../../pics/sliderPic/firstSlider.png"
import secondSlider from "../../../../../pics/sliderPic/secondSlider.png"
import thirdSlider from "../../../../../pics/sliderPic/thirdSlider.png"
import fourthSlider from "../../../../../pics/sliderPic/fourthSlider.png"


const AboutUsSlider = () => {
    const slides: { src: string, header: string, text: string }[] = [
        {
            "src": "firstSlider",
            "header": "ABOUT SushiRest",
            "text": "At our company, we take pride in our commitment to quality and customer satisfaction. Our success is a direct result of the hard work and dedication of our employees, who are truly the backbone of our business.\n" +
                "\n" +
                "Our team is made up of skilled professionals who are passionate about what they do. From our chefs and kitchen staff to our customer service representatives and management team, we are all committed to delivering the best possible experience for our customers.\n" +
                "\n" +
                "To ensure that our employees are equipped to succeed, we provide ongoing training and development opportunities, competitive wages and benefits packages, and a culture of open communication and collaboration. We believe in recognizing and rewarding our employees for their hard work and dedication, and fostering a positive and inclusive workplace culture where everyone feels valued and respected.\n" +
                "\n"
        },
        {
            "src": "secondSlider",
            "header": "Quality Products",
            "text": "We believe that using the freshest and highest quality ingredients is the key to creating exceptional dishes that stand out from the competition. \n" +
                "\n" +
                "Our team of expert chefs are trained to use innovative techniques and creative combinations to create visually stunning and delicious dishes that exceed our customers' expectations. \n" +
                "\n" +
                "We also understand that dietary needs and preferences vary among our customers, which is why we offer a wide variety of dishes to cater to different tastes and lifestyles. Whether you're a seafood lover, a vegan, or have specific dietary restrictions, we have something to offer you.\n" +
                "\n" +
                "From classic sushi rolls to unique and creative dishes, our menu is designed to cater to all tastes and preferences. We believe that food should not only taste great but also be visually appealing, which is why our chefs take great care in plating and presenting each dish with the utmost attention to detail.\n"
        },
        {
            "src": "thirdSlider",
            "header": "Customer Service",
            "text": "Our team of friendly and knowledgeable staff are always available to answer any questions and provide recommendations to help our customers find the perfect product for their needs. We believe that great customer service starts with a positive attitude and a willingness to go above and beyond to make our customers happy.\n" +
                "\n" +
                "Whether you're a first-time customer or a regular, our team is dedicated to making your experience with us a positive one. We understand that every customer is unique, which is why we take the time to listen to your needs and provide personalized service that is tailored to your preferences.\n" +
                "\n" +
                "We also believe in being transparent and upfront with our customers about our products, pricing, and policies. We want our customers to feel confident and informed about their purchases, which is why we are always happy to provide detailed information and answer any questions they may have.\n"
        },
        {
            "src": "fourthSlider",
            "header": "Employee Profiling",
            "text": "We understand that our employees are our greatest asset, which is why we invest in their training, development, and well-being. Each member of our team is carefully selected and trained to ensure they have the necessary skills and knowledge to provide exceptional service and deliver the highest quality products.\n" +
                "\n" +
                "We also believe in providing a supportive and inclusive work environment where all team members feel valued and respected. We encourage open communication and collaboration, and we strive to create a culture of mutual respect and understanding. Our team members bring a wide range of perspectives and ideas to the table, which allows us to innovate and improve our products and services.\n" +
                "\n" +
                "Overall, our commitment to employee profiling and diversity is a reflection of our core values and belief in the power of a diverse and inclusive workplace culture. We are proud of the talented individuals who make up our team and believe that their unique skills and perspectives are key to our success."}];
    //const slide = slides.map(s =>)


    const responsive = {
        desktop: {
            breakpoint: {max: 3000, min: 1024},
            items: 4,
            slidesToSlide: 1 // optional, default to 1.
        }
    };
    return (
        <Carousel
            className={style.slider}
            swipeable={true}
            draggable={true}
            showDots={true}
            responsive={responsive}
            ssr={true} // means to render carousel on server-side.
            infinite={true}
            autoPlay={false}
            autoPlaySpeed={1000}
            keyBoardControl={true}
            customTransition="all .5"
            transitionDuration={500}
            containerClass="carousel-container"
            removeArrowOnDeviceType={["tablet", "mobile"]}
            dotListClass="custom-dot-list-style"
            itemClass="carousel-item-padding-40-px"
        >
            <div className={style.items}>
                <img className={style.images} src={firstSlider}></img>
            </div>
            <div className={style.items}>
                <img className={style.images} src={secondSlider}></img>
            </div>
            <div className={style.items}>
                <img className={style.images} src={thirdSlider}></img>
            </div>
            <div className={style.items}>
                <img className={style.images} src={fourthSlider}></img>
            </div>
        </Carousel>
    );
}

export default AboutUsSlider;