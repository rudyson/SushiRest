import style from "./aboutUsSlider.module.scss"

// import Swiper core and required modules
import {Navigation, Pagination, A11y} from 'swiper/modules';
import {Swiper, SwiperSlide} from 'swiper/react';

// Import Swiper styles
import 'swiper/scss';
import 'swiper/scss/navigation'
import 'swiper/scss/pagination'
import 'swiper/scss/effect-coverflow'



import firstPic from "../../../../../pics/home/sliderAboutPic/firstSlider.png"
import secondPic from "../../../../../pics/home/sliderAboutPic/secondSlider.png"
import thirdPic from "../../../../../pics/home/sliderAboutPic/thirdSlider.png"
import fourthPic from "../../../../../pics/home/sliderAboutPic/fourthSlider.png"

export const AboutUsSlider = () => {
    return (
        <Swiper className={style.wrapper}
            // install Swiper modules
                modules={[Navigation, Pagination, A11y]}
                spaceBetween={40}
                slidesPerView={1.05}
                pagination={{clickable: true}}
                scrollbar={{draggable: true}}

        >
            <SwiperSlide className={style.el}>
                <div>
                    <img src={firstPic}></img>
                    <section>
                        <h3>ABOUT SushiRest</h3>
                        <article>At our company, we take pride in our commitment to quality and customer satisfaction. Our success is a direct result of the hard work and dedication of our employees, who are truly the backbone of our business.

                            Our team is made up of skilled professionals who are passionate about what they do. From our chefs and kitchen staff to our customer service representatives and management team, we are all committed to delivering the best possible experience for our customers.

                            To ensure that our employees are equipped to succeed, we provide ongoing training and development opportunities, competitive wages and benefits packages, and a culture of open communication and collaboration. We believe in recognizing and rewarding our employees for their hard work and dedication, and fostering a positive and inclusive workplace culture where everyone feels valued and respected.

                        </article>
                    </section>
                </div>
            </SwiperSlide>
            <SwiperSlide className={style.el}>
                <div>
                    <img src={secondPic}></img>
                    <section>
                        <h3>Quality Products</h3>
                        <article>At our company, we take pride in our commitment to quality and customer satisfaction. Our success is a direct result of the hard work and dedication of our employees, who are truly the backbone of our business.

                            Our team is made up of skilled professionals who are passionate about what they do. From our chefs and kitchen staff to our customer service representatives and management team, we are all committed to delivering the best possible experience for our customers.

                            To ensure that our employees are equipped to succeed, we provide ongoing training and development opportunities, competitive wages and benefits packages, and a culture of open communication and collaboration. We believe in recognizing and rewarding our employees for their hard work and dedication, and fostering a positive and inclusive workplace culture where everyone feels valued and respected.

                        </article>
                    </section>
                </div>
            </SwiperSlide>
            <SwiperSlide className={style.el}>
                <div>
                    <img src={thirdPic}></img>
                    <section>
                        <h3>Customer Service</h3>
                        <article>At our company, we take pride in our commitment to quality and customer satisfaction. Our success is a direct result of the hard work and dedication of our employees, who are truly the backbone of our business.

                            Our team is made up of skilled professionals who are passionate about what they do. From our chefs and kitchen staff to our customer service representatives and management team, we are all committed to delivering the best possible experience for our customers.

                            To ensure that our employees are equipped to succeed, we provide ongoing training and development opportunities, competitive wages and benefits packages, and a culture of open communication and collaboration. We believe in recognizing and rewarding our employees for their hard work and dedication, and fostering a positive and inclusive workplace culture where everyone feels valued and respected.

                        </article>
                    </section>
                </div>
            </SwiperSlide>
            <SwiperSlide className={style.el}>
                <div>
                    <img src={fourthPic}></img>
                    <section>
                        <h3>Employee Profiling</h3>
                        <article>At our company, we take pride in our commitment to quality and customer satisfaction. Our success is a direct result of the hard work and dedication of our employees, who are truly the backbone of our business.

                            Our team is made up of skilled professionals who are passionate about what they do. From our chefs and kitchen staff to our customer service representatives and management team, we are all committed to delivering the best possible experience for our customers.

                            To ensure that our employees are equipped to succeed, we provide ongoing training and development opportunities, competitive wages and benefits packages, and a culture of open communication and collaboration. We believe in recognizing and rewarding our employees for their hard work and dedication, and fostering a positive and inclusive workplace culture where everyone feels valued and respected.

                        </article>
                    </section>
                </div>
            </SwiperSlide>
        </Swiper>
    )
}
