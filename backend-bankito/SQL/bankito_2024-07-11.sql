create table public.role
(
    id   serial
        constraint pk_role primary key,
    name varchar(100) not null
);

create table public.users
(
    id                uuid                     not null
        constraint pk_users primary key,
    firstname         varchar(100)             not null,
    lastname          varchar(100)             not null,
    birthdate         timestamp with time zone not null,
    identity_document varchar(50)              not null,
    balance           double precision         not null,
    email             varchar(100)             not null,
    password_hash     varchar(256)             not null
);


create table public.user_role
(
    user_id uuid    not null
        constraint fk_user_role_users_user_id
            references public.users
            on delete cascade,
    role_id integer not null
        constraint fk_user_role_role_role_id
            references public.role
            on delete cascade,
    constraint pk_user_role
        primary key (user_id, role_id)
);


create table public.ban_type
(
    id   serial
        constraint pk_ban_type
            primary key,
    name varchar(100) not null
);

create table public.bank_transfer_status
(
    id   serial
        constraint pk_bank_transfer_status
            primary key,
    name varchar(100) not null
);

create table public.bill_status
(
    id   serial
        constraint pk_bill_status
            primary key,
    name varchar(100) not null
);

create table public.bill_type
(
    id   serial
        constraint pk_bill_type
            primary key,
    name varchar(100) not null
);

create table public.card_status
(
    id   serial
        constraint pk_card_status
            primary key,
    name varchar(100) not null
);

create table public.card
(
    id               serial
        constraint pk_card
            primary key,
    created_at       timestamp with time zone not null,
    deleted_at       timestamp with time zone,
    card_number      varchar(100)             not null,
    security_number  smallint                 not null,
    valid_until      timestamp with time zone not null,
    card_holder_name varchar(50)              not null,
    user_id          uuid                     not null
        constraint fk_card_users_user_id references public.users on delete cascade
);

create table public.country
(
    id      serial
        constraint pk_country primary key,
    name    varchar(100) not null,
    user_id uuid         not null
        constraint fk_country_users_user_id
            references public.users
            on delete cascade
);

create table public.ban
(
    id           serial
        constraint pk_ban
            primary key,
    from_date    timestamp with time zone not null,
    to_date      timestamp with time zone not null,
    reason       varchar(100),
    ban_type_id  integer                  not null
        constraint fk_ban_ban_type_ban_type_id
            references public.ban_type
            on delete cascade,
    user_id      uuid                     not null
        constraint fk_ban_users_user_id
            references public.users
            on delete cascade,
    banned_by_id uuid                     not null
        constraint fk_ban_users_banned_by_id
            references public.users
            on delete cascade
);

create table public.bank_transfer
(
    id                      serial
        constraint pk_bank_transfer
            primary key,
    amount                  double precision         not null,
    created_at              timestamp with time zone not null,
    source_user_id          uuid                     not null
        constraint fk_bank_transfer_users_source_user_id
            references public.users
            on delete cascade,
    target_user_id          uuid                     not null
        constraint fk_bank_transfer_users_target_user_id
            references public.users
            on delete cascade,
    bank_transfer_status_id integer                  not null
        constraint fk_bank_transfer_bank_transfer_status_bank_transfer_status_id
            references public.bank_transfer_status
            on delete cascade
);

create table public.bill
(
    id             serial
        constraint pk_bill
            primary key,
    amount         double precision         not null,
    expiry_at      timestamp with time zone not null,
    created_at     timestamp with time zone not null,
    bill_status_id integer                  not null
        constraint fk_bill_bill_status_bill_status_id
            references public.bill_status
            on delete cascade,
    bill_type_id   integer                  not null
        constraint fk_bill_bill_type_bill_type_id
            references public.bill_type
            on delete cascade,
    user_id        uuid                     not null
        constraint fk_bill_users_user_id
            references public.users
            on delete cascade
);

create table public.status_card
(
    id             serial
        constraint pk_status_card
            primary key,
    from_date      timestamp with time zone not null,
    to_date        timestamp with time zone,
    card_id        integer                  not null
        constraint fk_status_card_card_card_id
            references public.card
            on delete cascade,
    card_status_id integer                  not null
        constraint fk_status_card_card_status_card_status_id
            references public.card_status
            on delete cascade
);

create table public.payment
(
    id         serial
        constraint pk_payment
            primary key,
    amount     double precision         not null,
    created_at timestamp with time zone not null,
    bill_id    integer                  not null
        constraint fk_payment_bill_bill_id
            references public.bill
            on delete cascade
);

