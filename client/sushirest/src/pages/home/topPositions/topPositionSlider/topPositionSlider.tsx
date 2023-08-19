import style from "./topPositionSlider.module.scss"
import {A11y, Navigation, Pagination} from "swiper/modules"
import {Swiper, SwiperSlide} from "swiper/react"

import 'swiper/scss';
import 'swiper/scss/navigation'
import 'swiper/scss/pagination'

import {useEffect} from "react";
import {TopPosSlide} from "../../../../index.ts";
import {useDispatch, useSelector} from "react-redux";
import {fetchTopPosSlider} from "../../../../store/slices/topPosition/topPositionSlice.ts";

export const TopPositionSlider = () => {
    const items = useSelector((state) => state.topPosition.items)
    const dispatch = useDispatch()

    useEffect(() => {
        dispatch(fetchTopPosSlider())
    }, [])

    return (
        <div className={style.wrapper}>
            <Swiper className={style.wrapperSwiper}
                    modules={[Navigation, Pagination, A11y]}
                    spaceBetween={40}
                    slidesPerView={2}
                    loop={true}
                    pagination={{clickable: true, }}
                    scrollbar={{draggable: true}}
            >
                {items.map((obj, i) => (
                    <SwiperSlide key={i} className={style.el}>
                        <TopPosSlide key={obj.id} {...obj}/>
                    </SwiperSlide>
                ))}
            </Swiper>
        </div>
    )
}
