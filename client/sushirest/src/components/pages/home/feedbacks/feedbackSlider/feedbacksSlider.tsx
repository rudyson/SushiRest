import style from "./feedbacksSlider.module.scss"
import feedbacksMain from "../../../../../pics/home/feedbacks/feedbacksMain.png"
import {A11y, Navigation, Pagination} from "swiper/modules"
import {Swiper, SwiperSlide} from "swiper/react"
import {FeedbackSlide} from "../../../../../index.ts"

import 'swiper/scss';
import 'swiper/scss/navigation'
import 'swiper/scss/pagination'
export const FeedbacksSlider= () => {
    return (
        <div className={style.wrapper}>
            <img className={style.imgMain} src={feedbacksMain}></img>
            <Swiper className={style.wrapperSwiper}
                    modules={[Navigation, Pagination, A11y]}
                    spaceBetween={40}
                    slidesPerView={3}
                    loop={true}
                    centeredSlides={false}
                    pagination={{clickable: true, }}
                    scrollbar={{draggable: true}}
            >
                {[...Array(9)].map((obj) => (
                    <SwiperSlide className={style.el}>
                        <FeedbackSlide/>
                    </SwiperSlide>
                ))}
            </Swiper>
        </div>
    )
}
